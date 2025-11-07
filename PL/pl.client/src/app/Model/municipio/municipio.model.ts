import { Estado } from '../estado/estado.model';

export interface Municipio {
  IdMunicipio: number;
  Nombre: string;
  Estado: Estado;
  Municipios: any[];
}
