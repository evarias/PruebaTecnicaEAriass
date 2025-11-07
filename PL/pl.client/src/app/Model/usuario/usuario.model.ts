import { Cliente } from '../cliente/cliente.model';

export interface Usuario {
  IdUsuario: number;
  Cliente: Cliente;
  Email: string;
  Password: string;
  Status: boolean;
}
