import { Component } from '@angular/core';
import { Persona } from '../../models/persona.model'
import { PersonaService } from '../../services/persona.service'

@Component({
  selector: 'app-personaList',
  templateUrl: './personaList.component.html'
})
export class PersonaListComponent {

  public listPersonas: Persona[] = [];

  public displayedColumns = ["nombre", "apellido", "edad","grupoEtario","estadoCivil"];

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.personaService.getPersonas("", "").subscribe(data => {
      this.listPersonas = data;
    })
  }

}

