import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticuloService } from '../../Services/articulo.service';
import { Articulo } from '../../Model/articulo/articulo.model';

@Component({
  selector: 'app-articulo-form',
  standalone: false,
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  articulo: Articulo = {
    IdArticulo: 0,
    Codigo: '',
    Descripcion: '',
    Precio  : 0,
    Stock: 0
  };
  titulo: string = 'Nuevo Artículo';
  modoEdicion: boolean = false;

  constructor(
    private articuloService: ArticuloService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.modoEdicion = true;
      this.titulo = 'Editar Artículo';
      this.cargarArticulo(+id);
    }
  }

  cargarArticulo(id: number): void {
    this.articuloService.getById(id).subscribe({
      next: (res: any) => {
        const correct = res.Correct ?? res.correct;
        const obj = res.Object ?? res.object;
        if (correct && obj) {
          this.articulo = obj;
        }
      },
      error: (e) => console.error(e)
    });
  }

  guardar(): void {
    if (this.modoEdicion) {
      this.articuloService.update(this.articulo).subscribe({
        next: (res: any) => {
          const correct = res.Correct ?? res.correct;
        console.log(res)
          if (correct) {
            alert('Artículo actualizado correctamente');
            this.router.navigate(['/articulo']);
          } else {
            alert('No se pudo actualizar el artículo');
          }
        },
        error: (e) => {
          console.error(e);
          alert('Error al actualizar el artículo');
        }
      });
    } else {
      this.articuloService.add(this.articulo).subscribe({
        next: (res: any) => {
          console.log(res)
          const correct = res.Correct ?? res.correct;
          if (correct) {
            alert('Artículo agregado correctamente');
            this.router.navigate(['/articulo']); 
          } else {
            alert('No se pudo agregar el artículo');
          }
        },
        error: (e) => {
          console.error(e);
          alert('Error al agregar el artículo');
        }
      });
    }
  }


  cancelar(): void {
    this.router.navigate(['/articulo']);
  }
}
