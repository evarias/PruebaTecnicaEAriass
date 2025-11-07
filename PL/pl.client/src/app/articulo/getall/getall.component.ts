import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ArticuloService } from '../../Services/articulo.service';

@Component({
  selector: 'app-articulo-getall',
  templateUrl: './getall.component.html',
  standalone: false,
  styleUrls: ['./getall.component.css']
})
export class GetallComponent implements OnInit {
  articulos: any[] = [];
  error: string = '';
  titulo: string = 'Artículos';

  constructor(private articuloService: ArticuloService, private router: Router) { }

  ngOnInit(): void { this.cargar(); }

  cargar(): void {
    this.error = '';
    this.articuloService.getAll().subscribe({
      next: (res: any) => {
        console.log('Respuesta backend:', res);

        if (res.correct && res.objects && res.objects.length > 0) {
          this.articulos = res.objects;
          console.log('Artículos cargados:', this.articulos);
        } else {
          this.error = 'No se encontraron artículos';
        }
      },
      error: (e) => {
        console.error('Error en el servicio:', e);
        this.error = 'Error en el servicio';
      }
    });
  }

  nuevo(): void {
    this.router.navigate(['/articulo/nuevo']);
  }

  editar(id: number): void {
    console.log('ID recibido en editar:', id);
    if (!id) {
      alert('ID de artículo inválido');
      return;
    }
    this.router.navigate(['/articulo/editar', id]);
  }

  eliminar(id: number): void {
    console.log('ID recibido en eliminar:', id);
    if (!id) {
      alert('ID de artículo inválido');
      return;
    }

    if (confirm('¿Deseas eliminar este artículo?')) {
      this.articuloService.delete(id).subscribe({
        next: (res: any) => {
          if (res.correct) {
            alert('Artículo eliminado correctamente');
            this.cargar();
          } else {
            alert('No se pudo eliminar el artículo');
          }
        },
        error: (e) => {
          console.error('Error al eliminar:', e);
          alert('Error al eliminar el artículo');
        }
      });
    }
  }



}
