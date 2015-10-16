using System.ComponentModel.DataAnnotations;

//seguir o mesmo exemplo da classe EnumProposta
namespace CotacaoApp.Enumerations
{
    public class EnumCondutor
    {
    }

    public enum IESexo
    {
        //opções do radio button
        [Display(Name = "Masculino")]
        MASCULINO = 0,
        [Display(Name = "Feminino")]
        FEMININO = 1
    }

    public enum IEEstadoCivil
    {
        //opções do radio button
        [Display(Name = "Casado(a) ou reside há pelo menos 2 anos com companheiro(a)")]
        CASADOAOURESIDEHAPELOMENOS2ANOSCOMCOMPANHEIROA = 0,
        [Display(Name = "Separado(a)/Divorciado(a)")]
        SEPARADOADIVORCIADOA = 1,
        [Display(Name = " Solteiro(a)")]
        SOLTEIROA = 2,
        [Display(Name = "Viúvo(a)")]
        VIUVOA = 3
    }

    public enum IEPossuiOutrosCarros
    {
        //opções do radio button
        [Display(Name = "Sim")]
        SIM = 0,
        [Display(Name = "Não")]
        NAO = 1
    }

    public enum IEQuantidadeCarro
    {
        //opções do radio button
        [Display(Name = "Um")]
        UM = 1,
        [Display(Name = "Dois")]
        DOIS = 2,
        //opções do radio button
        [Display(Name = "Três")]
        TRES = 3,
        [Display(Name = "Quatro")]
        QUATRO = 4,
        [Display(Name = "Cinco ou mais Veículos")]
        CINCOOUMAISVEICULOS = 5
    }

    public enum IEProprietarioVeiculo
    {
        //opções do radio button
        [Display(Name = "Sim")]
        SIM = 0,
        [Display(Name = "Não")]
        NAO = 1,
    }
    
    public enum IERelacaoProprietario
    {
        //opções do radio button
        [Display(Name = "Cônjuge")]
        CONJUGE = 0,
        [Display(Name = "Filho(a) ou Enteado(a)")]
        FILHOAOUENTEADOA = 1,
        [Display(Name = "Operação de leasing")]
        OPERACAODELEASING = 2,
        [Display(Name = "Pai ou Mãe")]
        PAIOUMAE = 3,
        [Display(Name = "Diretor/Gerente/Sócio")]
        DIRETORGERENTESOCIO = 4,
        [Display(Name = "Funcionário")]
        FUNCIONARIO = 5,
        [Display(Name = "Motorista particular e leva o veiculo para casa")]
        MOTORISTAPARTICULALEVACARO = 6,
        [Display(Name = "Motorista particular e não leva o veiculo para casa")]
        MOTORISTAPARTICULANAOLEVACARO = 7,
        [Display(Name = "Outros")]
        OUTROS = 8,
    }

    public enum IECondutorPrincipal
    {
        //opções do radio button
        [Display(Name = "Condutor Principal")]
        CONDUTORPRINCIPAL = 0,
        [Display(Name = "Outra Pessoa")]
        OUTRAPESSOA = 1
    }

    public enum IETipoResidencia
    {
        //opções do radio button
        [Display(Name = "Apartamento ou flat")]
        APARTAMENTOOUFLAT = 0,
        [Display(Name = "Casa em condominio fechado")]
        CASAEMCONDOMINIOFECHADO = 1,
        [Display(Name = "Casa ou sobrado")]
        CASAOUSOBRADO = 2,
        [Display(Name = "Chácara, fazenda ou sítio")]
        CHACARAFAZENDAOUSITIO = 3,
        [Display(Name = "Outros")]
        OUTROS = 4,
        [Display(Name = "Não sei")]
        NAOSEI = 5,
    }

    public enum IERoubadoEm24Meses
    {
        //opções do radio button
        [Display(Name = "Sim")]
        SIM = 0,
        [Display(Name = "Não")]
        NAO = 1,
    }

    public enum IEAlgumCondutorEstuda
    {
        //opções do radio button
        [Display(Name = "Sim")]
        SIM = 0,
        [Display(Name = "Não")]
        NAO = 1,
    }

    public enum IENoticiasEmail
    {
        //opções do radio button
        //[Display(Name = "Sim, Autorizo receber informações sobre a cotação e descontos sobre o seguro por:")]
        //SIM = 0,
        //[Display(Name = "Não, Autorizo receber informações sobre a cotação e descontos sobre o seguro por:")]
        //NAO = 1,
    }


}