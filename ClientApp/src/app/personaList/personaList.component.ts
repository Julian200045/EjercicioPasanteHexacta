import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-personaList',
  templateUrl: './personaList.component.html'
})
export class PersonaListComponent {

  public listPersonas: Persona[] = [];

  constructor() { }
  
}

interface Persona {
  PersonaId: string;
  Nombre: string;
  Apellido: string;
  Edad: number;
  //GrupoEtario: GrupoEtario;
  //EstadoCivil: EstadoCivil;
}
