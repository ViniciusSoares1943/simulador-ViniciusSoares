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
    { label: 'Pessoa Física', value: PersonType.PF },
    { label: 'Pessoa Jurídica', value: PersonType.PJ }
  ];
  public modalityOptions = [
    { label: 'Pré-Fixado', value: Modality.FIXED },
    { label: 'Pós-Fixado', value: Modality.FLOATING }
  ]
  public productOptions: Product[] = [];

  constructor (
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private creditRateService: CreditRateService
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
    this.productService.getProductsByPersonType(personType).subscribe(products => {
      this.productOptions = products;
    });
  }

  public onSubmit(): void{
    console.log(this.form.value);
    if (this.form.invalid) return;
    this.creditResult = undefined;

    if (this.form.value.salary < 0) {
      this.form.get('salary')?.setErrors({ min: true });
      return;
    }

    this.creditRateService.simulateCreditRate(this.form.value).subscribe(res => {
      this.creditResult = res;
    });
  }
}
