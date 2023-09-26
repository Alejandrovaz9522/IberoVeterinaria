import { Propietario } from "./propietario";
import { Raza } from "./raza"
import { Tipo } from './tipo';

export class Mascota {
    mascotaId?: number
    propietarioId?: number
    nombre?: string
    razaId?: number
    tipoId?: number
    pesoLb?: string
    genero?: string
    raza?: Raza
    tipo?: Tipo
    propietario?: Propietario
}