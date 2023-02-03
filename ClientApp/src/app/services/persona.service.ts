import { Injectable } from '@angular/core'
import { Persona } from '../models/persona.model'
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(
    private http: HttpClient,
  ) { }

  getPersonas(nombre: string, apellido: string) {

    const url = environment.baseUrl + '/api/persona';

    console.log(url)

    let params = new HttpParams
    params.append("nombre", nombre);
    params.append("apellido", apellido);

    return this.http.get<Persona[]>(url, { params:params })
  }
}
