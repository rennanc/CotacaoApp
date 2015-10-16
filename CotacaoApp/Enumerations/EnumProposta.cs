using System.ComponentModel.DataAnnotations;

namespace CotacaoApp.Enumerations
{
    public class EnumProposta
    {

    }
    #region passo 1
    //referente ao radio button IEFinanciadoVeiculo
    public enum IEFinanciadoVeiculo
    {
        //opções do radio button
        [Display(Name = "Não é Financiado")] // texto
        NAOFINANCIADO = 0, //variavel = codigo
        [Display(Name = "Sim, é Financiado")]
        SIMFINANCIADO = 1,
        [Display(Name = "Sim, é Financiado e Alienado (CDC, Financiamento Direto, Leasing, Consórcio)")]
        SIMFINANCIADOCOMALIENACAO = 2
    }

    public enum IEZeroKM
    {
        //opções do radio button
        [Display(Name = "Sim")] // texto
        SIM = 0, //variavel (nao pode ter acento, deixe tudo em maiusculo) = codigo
        [Display(Name = "Não")]
        NAO = 1
    }

    public enum IEAlarmeVeiculo
    {
        //opções do radio button
        [Display(Name = "Alarme Sonoro")]
        ALARMESONORO = 0,
        [Display(Name = "Chave Codificada")]
        CHAVECODIFICADA = 1,
        [Display(Name = "Outros Dispositivos")]
        OUTROSDISPOSITIVOS = 2,
        [Display(Name = "Não Tenho Dispositivo")]
        NAOTENHODISPOSITIVO = 3
    }

    //Marque as opções nas quais seu carro se enquadra
    public enum IETipoVeiculoTaxi
    {
        //opções do radio button
        [Display(Name = "Não é Veiculo para Taxi")]
        NAO = 0,
        [Display(Name = "Veiculo usado pra Taxi")]
        SIM = 1
    }

    public enum IETipoVeiculoDeficiente
    {
        //opções do radio button
        [Display(Name = "Não é Adaptado para Deficiente Físico")]
        NAO = 0,
        [Display(Name = "Adaptado para Deficiente Físico")]
        SIM = 1
    }

    public enum IETipoVeiculoKitGas
    {
        //opções do radio button
        [Display(Name = "Não Tem Kit Gás")]
        NAO = 0,
        [Display(Name = "Tem Kit Gás")]
        SIM = 1
    }

    public enum IETipoVeiculoBlindado
    {
        //opções do radio button
        [Display(Name = "Não é Blindado")]
        NAO = 0,
        [Display(Name = "É Blindado")]
        SIM = 1
    }

    public enum IETipoVeiculoPessoaJuridica
    {
        //opções do radio button
        [Display(Name = "Não é Pessoa Juridica")]
        NAO = 0,
        [Display(Name = "É Pessoa Juridica")]
        SIM = 1
    }

    #endregion

    #region passo 2
    public enum IETipoEstacionamento
    {
        //opções do radio button
        [Display(Name = "Residência/Garagem")]
        RESIDENCIAGARAGEM = 0,
        [Display(Name = "Estacionamento")]
        ESTACIONAMENTO = 1,
        [Display(Name = "Outros")]
        OUTROS = 1,
    }

    public enum IETipoPortao
    {
        //opções do radio button
        [Display(Name = "Automático")]
        AUTOMATICO = 0,
        [Display(Name = "Manual")]
        MANUAL = 1,
        [Display(Name = "Com Porteiro")]
        COMPORTEIRO = 2,
        [Display(Name = "Sem Porteiro")]
        SEMPORTEIRO = 3
    }
    public enum IELocalGaragemTrabalho
    {
        //opções do radio button
        [Display(Name = "Sim, Com Portão Manual")]
        SIMCOMPORTAOMANUAL = 0,
        [Display(Name = "Sim, Com Portão Automatico ou com Porteiro")]
        SIMCOMPORTAOAUTOMATICOOUCOMPORTEIRO = 1,
        [Display(Name = "Sim, Em Estacionamento Privado Pago Ou Fechado")]
        SIMEMESTACIONAMENTOPRIVADOPAGOOUFECHADO = 2,
        [Display(Name = "Não")]
        NAO = 3,
    }

    public enum IEDistanciaParaTrabalhoVeiculo
    {
        //opções do radio button
        [Display(Name = "Até 10 KM")]
        ATE10KM = 0,
        [Display(Name = "Até 20 KM")]
        ATE20KM = 1,
        [Display(Name = "Até 30 KM")]
        ATE30KM = 2,
        [Display(Name = "Até 40 KM")]
        ATE40KM = 3,
        [Display(Name = "Acima de 40 Km")]
        ACIMADE40KM = 4,
    }

    public enum IELocalGaragemEstudo
    {
        //opções do radio button
        [Display(Name = "Sim, Com Portão Manual")]
        SIMCOMPORTAOMANUAL = 0,
        [Display(Name = "Sim, Com Portão Automático ou com Porteiro")]
        SIMCOMPORTAOAUTOMATICOOUCOMPORTEIRO = 1,
        [Display(Name = "Sim, Em Estacionamento Privado Pago Ou Fechado")]
        SIMEMESTACIONAMENTOPRIVADOPAGOOUFECHADO = 2,
        [Display(Name = "Não")]
        NAO = 3
    }

    public enum IEUtilizacaoVeiculoInstrumento
    {
        //opções do radio button
        [Display(Name = "Sim")]
        SIM = 0,
        [Display(Name = "Não")]
        NAO = 1
    }

    public enum IEUtilizacaoVeiculoInstrumentoForma
    {
        //opções do radio button
        [Display(Name = "Para entregas, representação comercial, vendedores, promotores e prestadores de serviços.")]
        PARAENTREGASREPRESENTACAOCOMERCIALVENDEDORESPROMOTORESEPRESTADORESDESERVICOS = 0,
        [Display(Name = "Para visitas a clientes, fornecedores e prospecção de novos negócios.")]
        PARAVISITASACLIENTESFORNECEDORESEPROSPECCAODENOVOSNEGOCIOS = 1,
        [Display(Name = "Utilizado em outras atividades não relacionadas acima.")]
        UTILIZADOEMOUTRASATIVIDADESNAORELACIONADASACIMA = 2
    }

    public enum IEKmEmMedia
    {
        //opções do radio button
        [Display(Name = "Até 500 km/mês (16 km dia)")]
        ATE500KMMES16KMDIA = 0,
        [Display(Name = "Até 1200 km/mês (40 km dia)")]
        ATE1200KMMES40KMDIA = 1,
        [Display(Name = "Acima de 1200 km/mês")]
        ACIMADE1200KMMES = 2
    }
    public enum IEUtilizacaoVeiculoLazer
    {
        //opções do radio button
        [Display(Name = "Não")]
        NAO = 0,
        [Display(Name = "Sim")]
        SIM = 1
    }

    public enum IEUtilizacaoVeiculoTrabalho
    {
        //opções do radio button
        [Display(Name = "Não")]
        NAO = 0,
        [Display(Name = "Sim")]
        SIM = 1
    }

    public enum IEUtilizacaoVeiculoEstudo
    {
        //opções do radio button
        [Display(Name = "Não")]
        NAO = 0,
        [Display(Name = "Sim")]
        SIM = 1
    }
    #endregion


    #region passo 3
    public enum IEMotivoCotacao
    {
        [Display(Name = "Só estou pesquisando para comprar um carro novo")]
        SOPESQUISANDO = 0,
        [Display(Name = "Fazer meu primeiro seguro para um carro que já tenho")]
        FAZERPRIMEIROSEGURO = 1
    }

    public enum IEPrimeiroSeguro
    {
        [Display(Name = "Já tenho cotações de outras corretoras")]
        JATENHOCOTACAO = 0,
        [Display(Name = "Ainda não tenho cotações de outras corretoras")]
        AINDANAOTENHOCOTACAO = 1
    }

    public enum IESeguroAtualQuerMaisOpcoes
    {
        [Display(Name = "Nao, quero mais opções de seguradoras e coberturas")]
        NAO = 0,
        [Display(Name = "Sim, quero mais opções de seguradoras e coberturas")]
        SIM = 1
    }

    public enum IESeguroAtualMelhorAtendimento
    {
        [Display(Name = "Não, estou em busca de um melhor atendimento")]
        NAO = 0,
        [Display(Name = "Sim, estou em busca de um melhor atendimento")]
        SIM = 1
    }

    public enum IESeguroAtualNaoSatisfeito
    {
        [Display(Name = "Não estou satisfeito com os preços que tenho")]
        NAO = 0,
        [Display(Name = "Sim estou satisfeito com os preços que tenho")]
        SIM = 1
    }

    public enum IEBonusSeguroAtualSemSinistro
    {
        [Display(Name = "Nenhum Bônus")]
        CLASSEZERO = 0,
        [Display(Name = "Um Bônus")]
        CLASSEUM = 1,
        [Display(Name = "Dois Bônus")]
        CLASSEDOIS = 2,
        [Display(Name = "Três Bônus")]
        CLASSETRES = 3,
        [Display(Name = "Quatro Bônus")]
        CLASSEQUATRO = 4,
        [Display(Name = "Cinco Bônus")]
        CLASSECINCO = 5,
        [Display(Name = "Seis Bônus")]
        CLASSESEIS = 6,
        [Display(Name = "Sete Bônus")]
        CLASSESETE = 7,
        [Display(Name = "Oito Bônus")]
        CLASSEOITO = 8,
        [Display(Name = "nove Bônus")]
        CLASSENOVE = 9,
        [Display(Name = "Dez Bônus")]
        CLASSEDEZ = 10
    }
    public enum IEBonusSeguroAtualComSinistro
    {
        [Display(Name = "Nenhum Sinistro")]
        SINISTROZERO = 0,
        [Display(Name = "Um Sinistro")]
        SINISTROUM = 1,
        [Display(Name = "Dois Sinistro")]
        SINISTRODOIS = 2,
        [Display(Name = "Três Sinistro")]
        SINISTROTRES = 3,
        [Display(Name = "Quatro Sinistro")]
        SINISTROQUATRO = 4,
        [Display(Name = "Cinco Sinistro")]
        SINISTROCINCO = 5,
    }
        #endregion passo 3
    }