import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteService } from '../../Services/cliente.service';

@Component({
  selector: 'app-cliente-getall',
  templateUrl: './getall.component.html',
  standalone: false,
  styleUrls: ['./getall.component.css']
  
})
export class GetallComponent implements OnInit {
  clientes: any[] = [];
  error: string = '';
  titulo: string = 'Clientes';

  constructor(private clienteService: ClienteService, private router: Router) { }

  ngOnInit(): void { this.cargar(); }

  cargar(): void {
    this.error = '';
    this.clienteService.getAll().subscribe({
      next: (res: any) => {
        if (res && res.Correct && res.Objects) {
          this.clientes = res.Objects as any[];
        } else {
          this.error = 'No se encontraron clientes';
        }
      },
      error: (e) => { console.error(e); this.error = 'Error en el servicio'; }
    });
  }

  nuevo(): void { this.router.navigate(['/cliente/nuevo']); }
  editar(id: number): void { this.router.navigate(['/cliente/editar', id]); }

  eliminar(id: number): void {
    this.clienteService.delete(id).subscribe({
      next: () => this.cargar(),
      error: (e) => console.error(e)
    });
  }
}
