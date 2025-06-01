import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { catchError, map, Observable, throwError } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getProductsByPersonType(personType: number): Observable<Product[]> {
    return this.http.get<any[]>(`${environment.baseUrl}/api/Produto/ObterPorTipoPessoa?tipoPessoa=${personType}`).pipe(
      map(data => data.map(item => ({
        name: item.nome,
        description: item.descricao,
        createdAt: new Date(item.dataCadastro),
        personType: item.tipoPessoa,
        productId: item.produtoId
      }))),
      catchError(error => {
        console.error('Erro ao buscar produtos:', error);
        return throwError(() => new Error('Erro ao buscar produtos.'));
      })
    );
  }
}
