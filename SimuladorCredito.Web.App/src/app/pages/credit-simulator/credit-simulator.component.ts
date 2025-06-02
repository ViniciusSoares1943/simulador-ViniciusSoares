import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CreditSimulatorReturn } from '../../models/credit-simulator-return.model';
import { PersonType } from '../../enums/person-type.enum';
import { Modality } from '../../enums/modality.enum';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { NgxMaskDirective } from 'ngx-mask';
import { CreditRateService } from '../../services/credit-rate.service';
import { finalize, catchError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';

@Component({
  selector: 'app-credit-simulator',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgxMaskDirective],
  templateUrl: './credit-simulator.component.html',
  styleUrl: './credit-simulator.component.scss'
})
export class CreditSimulatorComponent implements OnInit {

  public form!: FormGroup;
  public creditResult?: CreditSimulatorReturn;
  public personTypeOptions = [
    { label: 'Pessoa Física', value: PersonType.PF },
    { label: 'Pessoa Jurídica', value: PersonType.PJ }
  ];
  public modalityOptions = [
    { label: 'Pré-Fixado', value: Modality.FIXED },
    { label: 'Pós-Fixado', value: Modality.FLOATING }
  ]
  public productOptions: Product[] = [];
  public isLoadingProducts = false;
  public isLoadingSimulation = false;

  constructor (
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private creditRateService: CreditRateService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
   this.buildForm();
   this.changesValuesForm();
  }

  public buildForm(){
     this.form = this.formBuilder.group({
      personType: [null, Validators.required],
      modality: [null, Validators.required],
      productId: [null, Validators.required],
      salary: [null, Validators.required]
    });
  }

  public changesValuesForm() {
     this.form.get('personType')?.valueChanges.subscribe(personType => {
      if (personType) {
        this.loadProductsOptions(personType);
      } else {
        this.productOptions = [];
        this.form.get('productId')?.setValue(null);
      }
    });
  }

  private loadProductsOptions(personType: number): void {
    this.isLoadingProducts = true;
    this.productService.getProductsByPersonType(personType)
      .pipe(
        finalize(() => this.isLoadingProducts = false),
        catchError(error => {
          this.toastr.error('Erro ao carregar produtos. Por favor, tente novamente.');
          return of([]);
        })
      )
      .subscribe(products => {
        this.productOptions = products;
        if (products.length === 0) {
          this.toastr.warning('Nenhum produto encontrado para o tipo de pessoa selecionado.');
        }
      });
  }

  public onSubmit(): void{
    if (this.form.invalid) {
      this.toastr.error('Por favor, preencha todos os campos obrigatórios.');
      return;
    }

    this.creditResult = undefined;

    if (this.form.value.salary < 0) {
      this.form.get('salary')?.setErrors({ min: true });
      this.toastr.error('A renda não pode ser negativa.');
      return;
    }

    this.isLoadingSimulation = true;
    this.creditRateService.simulateCreditRate(this.form.value)
      .pipe(
        finalize(() => this.isLoadingSimulation = false),
        catchError(error => {
          this.toastr.error('Erro ao simular crédito. Por favor, tente novamente.');
          return of(null);
        })
      )
      .subscribe(res => {
        if (res) {
          this.creditResult = res;
          this.toastr.success('Simulação realizada com sucesso!');
        }
      });
  }
}
