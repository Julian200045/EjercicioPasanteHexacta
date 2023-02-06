import { Injectable } from '@angular/core'
import { Persona } from '../models/persona.model'
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { PersonaDTO } from '../dtos/persona.dto';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(
    private http: HttpClient,
  ) { }

  //DRY todo

  getPersonas(nombre: string, apellido: string) {

    const url = environment.baseUrl + '/api/persona';

    let params = new HttpParams
    params.append("nombre", nombre);
    params.append("apellido", apellido);

    return this.http.get<Persona[]>(url, { params:params })
  }

  handleError() {
    console.log("Error al hacer el post")
  }

  postPersona(personadto: PersonaDTO) {

    const url = environment.baseUrl + '/api/persona';

    console.log(personadto)

    return this.http.post<PersonaDTO>(url, personadto);
  }
}
