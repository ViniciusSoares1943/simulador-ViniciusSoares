import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CreditSimulatorInput } from '../models/credit-simulator-input.model';
import { CreditSimulatorReturn } from '../models/credit-simulator-return.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreditRateService {

  constructor(private http: HttpClient) { }

  private apiUrl = `${environment.baseUrl}/api/TaxaCredito`;

  public simulateCreditRate(input: CreditSimulatorInput): Observable<CreditSimulatorReturn> {
    const params = this.mapToBackendPayload(input);
    return this.http.post<any>(`${this.apiUrl}/SimularCredito`, params).pipe(
      map(data => ({
        segmentName: data.nomeSegmento,
        creditRate: data.taxa * 100
      })),
      catchError(error => {
        console.error('Erro ao simular crédito:', error);
        return throwError(() => new Error('Erro ao simular crédito.'));
      })
    );
  }

  private mapToBackendPayload(input: CreditSimulatorInput): any {
    return {
      tipoPessoa: Number(input.personType),
      modalidade: Number(input.modality),
      produtoId: Number(input.productId),
      renda: input.salary
    };
  }
}
