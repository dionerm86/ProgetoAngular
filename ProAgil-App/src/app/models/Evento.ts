import { Lote } from "./Lote";
import { RedeSocial } from "./RedeSocial";
import { Palestrante } from "./Palestrante";

export interface Evento {

    id: number;

    local : string;

    dataEvento : Date

    tema : string;

    qtdPessoas : number;

    imagemURL : string;

    email : string;

    telefone : string;

    lotes: Lote[];

    redesSociais: RedeSocial[];

    palestrantesEventos: Palestrante[];
}
