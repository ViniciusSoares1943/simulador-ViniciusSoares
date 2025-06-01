import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CreditSimulatorReturn } from '../../models/credit-simulator-return.model';
import { PersonType } from '../../enums/person-type.enum';
import { Modality } from '../../enums/modality.enum';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { NgxMaskDirective } from 'ngx-mask';

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
    private productService: ProductService
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
      salary: [null, Validators.required, Validators.min(0)]
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
    if (this.form.invalid) return;

  }

}
