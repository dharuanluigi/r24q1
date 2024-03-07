using System.ComponentModel.DataAnnotations;

namespace r24q1.DTOs;

public record NewTransaction(
    int Valor,

    [RegularExpression(pattern: "^c$|^d$")]
    char Tipo,
    
    [MaxLength(10)]
    string Descricao
);