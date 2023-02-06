import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PersonaDTO } from '../../dtos/persona.dto';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-add-persona-form',
  templateUrl: './add-persona-form.component.html'
})
export class AddPersonaFormComponent {

  estadosCiviles = ['Soltero','Casado','Separado','Divorciado','Viudo'] //Posiblemente lo mande el back TODO

  submitted = false;

  constructor(private personaService: PersonaService) {

  }

  onSubmit() {
    this.submitted = true
  }


  onPersonaAdd(persona: { pNombre: string, pApellido: string, pEdad: number, pEstadoCivil: string })
  {
    console.log(persona)

    this.personaService.postPersona(new PersonaDTO(persona.pNombre, persona.pApellido, persona.pEdad, persona.pEstadoCivil)).subscribe(data => data);
  }

  ngOnInit(): void {
   
    
  }

}

