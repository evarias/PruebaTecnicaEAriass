import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../../Services/cliente.service';
import { Cliente } from '../../Model/cliente/cliente.model';

@Component({
  selector: 'app-cliente-form',
  standalone: false,
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  id: number = 0;
  nombre: string = '';
  apellidoPaterno: string = '';
  apellidoMaterno: string = '';
  error: string = '';
  titulo: string = 'Cliente';

  constructor(private route: ActivatedRoute, private router: Router, private clienteService: ClienteService) { }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id = Number(idParam);
      if (this.id > 0) this.getById();
    }
  }

  guardar(): void {
    this.id > 0 ? this.update() : this.add();
  }

  getById(): void {
    this.clienteService.getById(this.id).subscribe({
      next: res => {
        if (res && res.Correct && res.Object) {
          const c = res.Object as Cliente;
          this.id = c.IdCliente;
          this.nombre = c.Nombre;
          this.apellidoPaterno = c.ApellidoPaterno;
          this.apellidoMaterno = c.ApellidoMaterno;
        }
      },
      error: e => console.error(e)
    });
  }

  add(): void {
    this.clienteService.add(this.nombre, this.apellidoPaterno, this.apellidoMaterno).subscribe({
      next: res => { if (res && res.Correct) this.router.navigate(['/cliente']); },
      error: e => { console.error(e); this.error = 'Error al agregar'; }
    });
  }

  update(): void {
    const clienteActualizar: Cliente = {
      IdCliente: this.id,
      Nombre: this.nombre,
      ApellidoPaterno: this.apellidoPaterno,
      ApellidoMaterno: this.apellidoMaterno
    };
    this.clienteService.update(clienteActualizar).subscribe({
      next: res => { if (res && res.Correct) this.router.navigate(['/cliente']); },
      error: e => { console.error(e); this.error = 'Error al actualizar'; }
    });
  }
}
