import { Colonia } from '../colonia/colonia.model';

export interface Direccion {
  IdDireccion: number;
  Calle: string;
  NumeroInterior: string;
  NumeroExterior: string;
  Colonia: Colonia;
}
