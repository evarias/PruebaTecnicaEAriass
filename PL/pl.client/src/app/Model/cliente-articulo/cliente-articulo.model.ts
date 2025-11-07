import { Cliente } from '../cliente/cliente.model';
import { Articulo } from '../articulo/articulo.model';

export interface ClienteArticulo {
  IdClienteArticulo: number;
  Cliente: Cliente;
  Articulo: Articulo;
  Fecha: string;
}
