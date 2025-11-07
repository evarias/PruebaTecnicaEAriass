import { Direccion } from '../direccion/direccion.model';

export interface Tienda {
  IdTienda: number;
  Sucursal: string;
  Direccion?: Direccion;
}
