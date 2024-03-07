namespace r24q1.DTOs;

public record Extract(
    int Valor,

    char Tipo,

    string Descricao,

    DateTime Realizada_em
);