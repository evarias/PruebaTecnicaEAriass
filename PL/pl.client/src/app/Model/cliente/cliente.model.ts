import { Direccion } from '../direccion/direccion.model';

export interface Cliente {
  IdCliente: number;
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Direccion?: Direccion;
}
