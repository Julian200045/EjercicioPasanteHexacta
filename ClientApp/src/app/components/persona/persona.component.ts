import { Component, OnInit, Input, OnChanges } from '@angular/core'
import {Persona } from '../../models/persona.model'

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html'
})
export class PersonaComponent implements OnInit, OnChanges{

  @Input() persona: Persona = {
    nombre: "",
    apellido: "",
    edad: 0,
    grupoEtario: "",
    estadoCivil: ""
    }

  constructor() {
    console.log('constructor', 'persona:', this.persona);
  }

  ngOnChanges() {
    console.log('onChanges')
  }

  ngOnInit(){
    console.log('onInit')
  }
}
