import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TiendaService } from '../../Services/tienda.service';
import { Tienda } from '../../Model/tienda/tienda.model';

@Component({
  selector: 'app-tienda-form',
  standalone: false,
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  id: number = 0;
  sucursal: string = '';
  error: string = '';
  titulo: string = 'Tienda';

  constructor(private route: ActivatedRoute, private router: Router, private tiendaService: TiendaService) { }

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
    this.tiendaService.getById(this.id).subscribe({
      next: res => {
        if (res && res.Correct && res.Object) {
          const t = res.Object as Tienda;
          this.id = t.IdTienda;
          this.sucursal = t.Sucursal || '';
        }
      },
      error: e => console.error(e)
    });
  }

  add(): void {
    this.tiendaService.add(this.sucursal).subscribe({
      next: res => { if (res && res.Correct) this.router.navigate(['/tienda']); },
      error: e => { console.error(e); this.error = 'Error al agregar'; }
    });
  }

  update(): void {
    const tiendaActualizar: Tienda = { IdTienda: this.id, Sucursal: this.sucursal };
    this.tiendaService.update(tiendaActualizar).subscribe({
      next: res => { if (res && res.Correct) this.router.navigate(['/tienda']); },
      error: e => { console.error(e); this.error = 'Error al actualizar'; }
    });
  }
}
