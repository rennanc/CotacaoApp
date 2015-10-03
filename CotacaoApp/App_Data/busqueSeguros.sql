-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema corretorBD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema corretorBD
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `corretorBD` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `corretorBD` ;

-- -----------------------------------------------------
-- Table `corretorBD`.`Condutor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Condutor` (
  `CD_CONDUTOR` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_SEGURADO` INT NOT NULL COMMENT '',
  `CD_CPF` INT NOT NULL COMMENT '',
  `IE_SEGURADO` INT NULL COMMENT '',
  `NM_NOME` VARCHAR(250) NOT NULL COMMENT '',
  `DT_NASCIMENTO` DATE NULL COMMENT '',
  `IE_SEXO` VARCHAR(2) NULL COMMENT '',
  `NM_ESTADOCIVIL` VARCHAR(45) NULL COMMENT '',
  `NR_CEP` VARCHAR(10) NULL COMMENT '',
  `IE_POSSUIOUTROSCARROS` INT NULL COMMENT '',
  `IE_QTDCARROS` INT NULL COMMENT '',
  `NR_ANOSCNH` INT NULL COMMENT '',
  `NM_EMAIL` VARCHAR(300) NULL COMMENT '',
  `NM_BANCO` VARCHAR(250) NULL COMMENT '',
  `IE_PROPRIETARIOVEICULO` INT NULL COMMENT '',
  `IE_RELACAOPROPRIETARIO` INT NULL COMMENT '',
  `IE_CONDPRINCIPAL` INT NULL COMMENT '',
  `IE_TIPORESIDENCIA` INT NULL COMMENT '',
  `DS_PROFISSAO` VARCHAR(300) NULL COMMENT '',
  `IE_ROUBADOEM24MESES` INT NULL COMMENT '',
  `IE_ALGUMCONDUTORESTUDA` INT NULL COMMENT '',
  `IE_NOTICIASEMAIL` INT NULL COMMENT '',
  `IE_ITAUPERSONALITE` INT NULL COMMENT '',
  `IE_CARTAOPORTOSEGUROVISA` INT NULL COMMENT '',
  PRIMARY KEY (`CD_CONDUTOR`)  COMMENT '',
  INDEX `FK_CONDUTOR_SEGURADO_idx` (`CD_SEGURADO` ASC)  COMMENT '',
  CONSTRAINT `FK_CONDUTOR_SEGURADO`
    FOREIGN KEY (`CD_SEGURADO`)
    REFERENCES `corretorBD`.`Condutor` (`CD_CONDUTOR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Telefone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Telefone` (
  `CD_CONDUTOR` INT NOT NULL COMMENT '',
  `NR_TELEFONE` VARCHAR(45) NOT NULL COMMENT '',
  INDEX `FK_TELEFONE_PESSOA_idx` (`CD_CONDUTOR` ASC)  COMMENT '',
  PRIMARY KEY (`CD_CONDUTOR`)  COMMENT '',
  CONSTRAINT `FK_TELEFONE_CONDUTOR`
    FOREIGN KEY (`CD_CONDUTOR`)
    REFERENCES `corretorBD`.`Condutor` (`CD_CONDUTOR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Usuario` (
  `CD_USUARIO` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `NM_USUARIO` VARCHAR(250) NOT NULL COMMENT '',
  `NM_NOME` VARCHAR(250) NOT NULL COMMENT '',
  `NM_SENHA` VARCHAR(45) NOT NULL COMMENT '',
  `FL_PERMISSAO` INT ZEROFILL NOT NULL COMMENT '',
  PRIMARY KEY (`CD_USUARIO`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Comissao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Comissao` (
  `CD_COMISSAO` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_USUARIO` INT NOT NULL COMMENT '',
  `VR_PREMIO_LIQUIDO` DECIMAL NULL COMMENT '',
  `VR_PERC_COMISSAO` DECIMAL NULL COMMENT '',
  `VR_COMISSAO_LIQUIDA` DECIMAL NULL COMMENT '',
  `VR_PERCISS` DECIMAL NULL COMMENT '',
  `VR_PERCIR` DECIMAL NULL COMMENT '',
  PRIMARY KEY (`CD_COMISSAO`)  COMMENT '',
  INDEX `FK_COMISSAO_USUARIO_idx` (`CD_USUARIO` ASC)  COMMENT '',
  CONSTRAINT `FK_COMISSAO_USUARIO`
    FOREIGN KEY (`CD_USUARIO`)
    REFERENCES `corretorBD`.`Usuario` (`CD_USUARIO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Seguradora`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Seguradora` (
  `CD_SEGURADORA` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `NM_SEGURADORA` VARCHAR(250) NULL COMMENT '',
  PRIMARY KEY (`CD_SEGURADORA`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Proposta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Proposta` (
  `CD_PROPOSTA` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_CONDUTOR` INT NOT NULL COMMENT '',
  `NM_MARCAVEICULO` VARCHAR(45) NULL COMMENT '',
  `NR_ANOFABVEICULO` INT NULL COMMENT '',
  `NR_ANOMODELOVEICULO` INT NULL COMMENT '',
  `IE_ZEROKM` INT NULL COMMENT '',
  `NM_VEICULO` VARCHAR(450) NULL COMMENT '',
  `IE_FINANCIADOVEICULO` INT NULL COMMENT '',
  `IE_TIPOVEICULO_TAXI` INT NULL COMMENT '',
  `IE_TIPOVEICULO_DEFICIENTE` INT NULL COMMENT '',
  `IE_TIPOVEICULO_KITGAS` INT NULL COMMENT '',
  `IE_TIPOVEICULO_BLINDADO` INT NULL COMMENT '',
  `IE_TIPOVEICULO_PESSOAJURIDICA` INT NULL COMMENT '',
  `IE_ALARMEVEICULO` INT NULL COMMENT '',
  `IE_TIPOESTACION` INT NULL COMMENT '',
  `IE_TIPOPORTAO` INT NULL COMMENT '',
  `NR_CEPESTACION` VARCHAR(8) NULL COMMENT '',
  `NR_CEPDESLOC` VARCHAR(8) NULL COMMENT '',
  `IE_UTILIZACAOVEICULO_LAZER` INT NULL COMMENT '',
  `IE_UTILIZACAOVEICULO_TRABALHO` INT NULL COMMENT '',
  `IE_UTILIZACAOVEICULO_ESTUDO` INT NULL COMMENT '',
  `IE_UTILIZACAOVEICULO_INSTRUMENTO` INT NULL COMMENT '',
  `IE_TIPOGARAGEMTRABALHO` INT NULL COMMENT '',
  `IE_DISTANCIATRABVEICULO` INT NULL COMMENT '',
  `IE_TIPOGARAGEMESTUDO` INT NULL COMMENT '',
  `IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA` INT NULL COMMENT '',
  `IE_MEDIAKMVEICULO` INT NULL COMMENT '',
  `IE_MOTIVO_COTACAO` INT NULL COMMENT '',
  `IE_PRIMEIROSEGURO` INT NULL COMMENT '',
  `IE_SEGUROATUAL_QUERMAISOPCOES` INT NULL COMMENT '',
  `IE_SEGUROATUAL_MELHORATENDIMENTO` INT NULL COMMENT '',
  `IE_SEGUROATUAL_NAOSATISFEITO` INT NULL COMMENT '',
  `NM_SEGURADORAATUAL` VARCHAR(250) NULL COMMENT '',
  `DT_VENC_SEGUROATUAL` DATETIME NULL COMMENT '',
  `IE_BONUSAPOLICEATUAL_SEMSINISTRO` INT NULL COMMENT '',
  `IE_BONUSAPOLICEATUAL_COMSINISTRO` INT NULL COMMENT '',
  `NR_APOLICE` VARCHAR(45) NULL COMMENT '',
  `NR_CI` VARCHAR(45) NULL COMMENT '',
  `NR_PLACAVEICULO` VARCHAR(7) NULL COMMENT '',
  `NR_CHASSIVEICULO` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`CD_PROPOSTA`, `CD_CONDUTOR`)  COMMENT '',
  INDEX `FK_PROPOSTA_CONDUTOR_idx` (`CD_CONDUTOR` ASC)  COMMENT '',
  CONSTRAINT `FK_PROPOSTA_CONDUTOR`
    FOREIGN KEY (`CD_CONDUTOR`)
    REFERENCES `corretorBD`.`Condutor` (`CD_CONDUTOR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Apolice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Apolice` (
  `CD_APOLICE` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_PROPOSTA` INT NOT NULL COMMENT '',
  `CD_COMISSAO` INT NOT NULL COMMENT '',
  `CD_SEGURADORA` INT NOT NULL COMMENT '',
  `VL_CONTRATO` VARCHAR(45) NULL COMMENT '',
  `SG_STATUS` VARCHAR(1) NULL COMMENT '',
  `NM_SEGURADORA` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`CD_APOLICE`, `CD_PROPOSTA`)  COMMENT '',
  INDEX `fk_Apolice_Comissao1_idx` (`CD_COMISSAO` ASC)  COMMENT '',
  INDEX `fk_Apolice_Seguradora1_idx` (`CD_SEGURADORA` ASC)  COMMENT '',
  INDEX `fk_Apolice_Proposta2_idx` (`CD_PROPOSTA` ASC)  COMMENT '',
  CONSTRAINT `fk_Apolice_Comissao1`
    FOREIGN KEY (`CD_COMISSAO`)
    REFERENCES `corretorBD`.`Comissao` (`CD_COMISSAO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Apolice_Seguradora1`
    FOREIGN KEY (`CD_SEGURADORA`)
    REFERENCES `corretorBD`.`Seguradora` (`CD_SEGURADORA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Apolice_Proposta2`
    FOREIGN KEY (`CD_PROPOSTA`)
    REFERENCES `corretorBD`.`Proposta` (`CD_PROPOSTA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Cobertura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Cobertura` (
  `CD_COBERTURA` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `NM_COBERTURA` VARCHAR(45) NULL COMMENT '',
  `SG_TIPO` VARCHAR(45) NULL COMMENT '',
  `DS_COBERTURA` VARCHAR(4000) NULL COMMENT '',
  PRIMARY KEY (`CD_COBERTURA`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`ValorProposta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`ValorProposta` (
  `CD_VALORPROPOSTA` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_CONDUTOR` INT NOT NULL COMMENT '',
  `CD_APOLICE` INT NOT NULL COMMENT '',
  `DS_DESCRICAO` VARCHAR(45) NULL COMMENT '',
  `DS_TIPO` VARCHAR(45) NULL COMMENT '',
  `DT_DATA VENCIMENTO` VARCHAR(45) NULL COMMENT '',
  `VL_VALOR` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`CD_VALORPROPOSTA`, `CD_CONDUTOR`)  COMMENT '',
  INDEX `FK_PAGAMENTO_APOLICE_idx` (`CD_APOLICE` ASC)  COMMENT '',
  INDEX `FK_VALORPROPOSTA_CONDUTOR_idx` (`CD_CONDUTOR` ASC)  COMMENT '',
  CONSTRAINT `FK_VALORPROSTA_APOLICE`
    FOREIGN KEY (`CD_APOLICE`)
    REFERENCES `corretorBD`.`Apolice` (`CD_APOLICE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_VALORPROPOSTA_CONDUTOR`
    FOREIGN KEY (`CD_CONDUTOR`)
    REFERENCES `corretorBD`.`Condutor` (`CD_CONDUTOR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Endosso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Endosso` (
  `CD_ENDOSSO` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CD_APOLICE` INT NOT NULL COMMENT '',
  `DT_ALTERACAO_ENDOSSO` DATETIME NULL COMMENT '',
  `DT_ENDOSSO` DATETIME NULL COMMENT '',
  PRIMARY KEY (`CD_ENDOSSO`)  COMMENT '',
  INDEX `fk_Endosso_Apolice1_idx` (`CD_APOLICE` ASC)  COMMENT '',
  CONSTRAINT `fk_Endosso_Apolice1`
    FOREIGN KEY (`CD_APOLICE`)
    REFERENCES `corretorBD`.`Apolice` (`CD_APOLICE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `corretorBD`.`Proposta_Cobertura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `corretorBD`.`Proposta_Cobertura` (
  `CD_PROPOSTA` INT NOT NULL COMMENT '',
  `CD_COBERTURA` INT NOT NULL COMMENT '',
  PRIMARY KEY (`CD_PROPOSTA`, `CD_COBERTURA`)  COMMENT '',
  INDEX `FK_APOLICESINISTRO_SINISTRO_idx` (`CD_COBERTURA` ASC)  COMMENT '',
  CONSTRAINT `FK_PROPOSTACOBERTURA_PROPOSTA`
    FOREIGN KEY (`CD_PROPOSTA`)
    REFERENCES `corretorBD`.`Proposta` (`CD_PROPOSTA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_PROPOSTACOBERTURA_COBERTURA`
    FOREIGN KEY (`CD_COBERTURA`)
    REFERENCES `corretorBD`.`Cobertura` (`CD_COBERTURA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
