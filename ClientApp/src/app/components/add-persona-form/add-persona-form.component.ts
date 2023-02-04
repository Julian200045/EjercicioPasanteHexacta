import { Component } from '@angular/core';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-add-persona-form',
  templateUrl: './add-persona-form.component.html'
})
export class AddPersonaFormComponent {

  

  constructor(private personaService: PersonaService) {

  }

  onPersonaAdd(persona: { pNombre: string, pApellido: string, pEdad: number, pEstadoCivil: string })
  {
    console.log(persona)
  }

  ngOnInit(): void {
   
    
  }

}

