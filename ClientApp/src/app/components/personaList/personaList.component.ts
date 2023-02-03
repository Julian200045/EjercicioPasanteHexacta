import { Component, Inject } from '@angular/core';
import { Persona } from '../../models/persona.model'
import { PersonaService } from '../../services/persona.service'

@Component({
  selector: 'app-personaList',
  templateUrl: './personaList.component.html'
})
export class PersonaListComponent {

  public listPersonas: Persona[] = [];

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.personaService.getPersonas("", "").subscribe(data => {
      console.log(data)
    })
  }

}

