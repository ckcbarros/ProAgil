import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable()

// Quando definir o principal http para todo o projeto - no component de cada evento precisa adicionar individualmente no provider o EventoService
// ou entao incluir no app.modelues o EventoService
/* @Injectable({
  providedIn: 'root'
})
 */

export class EventoService {

  baseURL = 'http://localhost:5000/api/evento';

  constructor(private http: HttpClient) {}

  getAllEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>('${this.baseURL}/getByTema/${tema}');
  }

  getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>('${this.baseURL}/${id}');
  }

}
