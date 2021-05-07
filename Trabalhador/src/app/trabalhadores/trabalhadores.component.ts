import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Trabalhador } from '../models/Trabalhador';

@Component({
  selector: 'app-trabalhadores',
  templateUrl: './trabalhadores.component.html',
  styleUrls: ['./trabalhadores.component.css']
})
export class TrabalhadoresComponent implements OnInit {

  public trabalhadorForm: FormGroup;
  titulo = 'Empregados';
  public trabalhadorSelecionado: Trabalhador;

  trabalhadores = [
    {nome: 'teste1', sobrenome: '', valeTransporte: 0, cargaDeTrabalho: '', custoTotal: 0},
    {nome: 'teste2', sobrenome: '', valeTransporte: 0, cargaDeTrabalho: '', custoTotal: 0},
    {nome: 'teste3', sobrenome: '', valeTransporte: 0, cargaDeTrabalho: '', custoTotal: 0}
  ];

  constructor(private fb: FormBuilder) { 
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm(){
    this.trabalhadorForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      valeTransport: ['', Validators.required],
      cargaDeTrabalho: ['', Validators.required]
    });
  }

  trabalhadorSubmit()
  {
    console.log(this.trabalhadorForm.value);

  }

  trabalhadorSelect(trabalhadores: Trabalhador)
  {
    this.trabalhadorSelecionado = trabalhadores;
    this.trabalhadorForm.patchValue(trabalhadores);
  }

  voltar(){
    this.trabalhadorSelecionado = null;
  }

 
}
