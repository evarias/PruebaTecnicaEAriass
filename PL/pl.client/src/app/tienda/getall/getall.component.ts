import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TiendaService } from '../../Services/tienda.service';

@Component({
  selector: 'app-tienda-getall',
  templateUrl: './getall.component.html',
  standalone: false,
  styleUrls: ['./getall.component.css']
})
export class GetallComponent implements OnInit {
  tiendas: any[] = [];
  error: string = '';
  titulo: string = 'Tiendas';

  constructor(private tiendaService: TiendaService, private router: Router) { }

  ngOnInit(): void { this.cargar(); }

  cargar(): void {
    this.error = '';
    this.tiendaService.getAll().subscribe({
      next: (res: any) => {
        if (res && res.Correct && res.Objects) {
          this.tiendas = res.Objects as any[];
        } else {
          this.error = 'No se encontraron tiendas';
        }
      },
      error: (e) => { console.error(e); this.error = 'Error en el servicio'; }
    });
  }

  nuevo(): void { this.router.navigate(['/tienda/nuevo']); }
  editar(id: number): void { this.router.navigate(['/tienda/editar', id]); }

  eliminar(id: number): void {
    this.tiendaService.delete(id).subscribe({
      next: () => this.cargar(),
      error: (e) => console.error(e)
    });
  }
}
