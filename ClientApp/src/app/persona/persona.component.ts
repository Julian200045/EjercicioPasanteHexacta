import { Component, OnInit,Input } from '@angular/core'

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html'
})
export class PersonaComponent {

  @Input() nombre: string = "nombre"

  constructor() { }

  ngOnInit(): void {

  }
}
