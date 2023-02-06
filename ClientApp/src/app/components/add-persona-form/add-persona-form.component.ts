import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PersonaDTO } from '../../dtos/persona.dto';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-add-persona-form',
  templateUrl: './add-persona-form.component.html',
  styleUrls: ['./add-persona-form.component.scss']
})
export class AddPersonaFormComponent implements OnInit {

  estadosCiviles = ['Soltero','Casado','Separado','Divorciado','Viudo'] //Posiblemente lo mande el back TODO

  submitted = false;

  reactiveForm: FormGroup;

  

  constructor(private personaService: PersonaService) {

  }

  onSubmit() {
    this.submitted = true
  }


  onPersonaAdd()
  {

    console.log(this.reactiveForm.value)

    let dto = new PersonaDTO(this.reactiveForm.value.nombre, this.reactiveForm.value.apellido, this.reactiveForm.value.edad, this.reactiveForm.value.estadoCivil);

    this.personaService.postPersona(dto).subscribe(data => data);
  }


  ngOnInit(): void {
    this.reactiveForm = new FormGroup({

      nombre: new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Z ]*')]),

      apellido: new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Z ]*')]),

      edad: new FormControl(null, [Validators.required, Validators.pattern('[0-9]*'), Validators.min(0)]),

      estadoCivil: new FormControl(null, [Validators.required])

     })

    
  }

}

