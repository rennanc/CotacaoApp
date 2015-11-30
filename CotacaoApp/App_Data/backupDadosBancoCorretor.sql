CREATE DATABASE  IF NOT EXISTS `corretorbd` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `corretorbd`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: br-cdbr-azure-south-a.cloudapp.net    Database: corretorbd
-- ------------------------------------------------------
-- Server version	5.5.45-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `apolice`
--

DROP TABLE IF EXISTS `apolice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `apolice` (
  `CD_APOLICE` int(11) NOT NULL AUTO_INCREMENT,
  `CD_PROPOSTA` int(11) NOT NULL,
  `CD_COMISSAO` int(11) NOT NULL,
  `CD_SEGURADORA` int(11) NOT NULL,
  `VL_CONTRATO` decimal(10,2) DEFAULT '0.00',
  `SG_STATUS` int(11) DEFAULT '0',
  `FL_MODIFICADA` int(11) DEFAULT '0',
  PRIMARY KEY (`CD_APOLICE`,`CD_PROPOSTA`),
  KEY `fk_Apolice_Comissao1_idx` (`CD_COMISSAO`),
  KEY `fk_Apolice_Seguradora1_idx` (`CD_SEGURADORA`),
  KEY `fk_Apolice_Proposta2_idx` (`CD_PROPOSTA`),
  CONSTRAINT `fk_Apolice_Comissao1` FOREIGN KEY (`CD_COMISSAO`) REFERENCES `comissao` (`CD_COMISSAO`),
  CONSTRAINT `fk_Apolice_Proposta2` FOREIGN KEY (`CD_PROPOSTA`) REFERENCES `proposta` (`CD_PROPOSTA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Apolice_Seguradora1` FOREIGN KEY (`CD_SEGURADORA`) REFERENCES `seguradora` (`CD_SEGURADORA`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apolice`
--

LOCK TABLES `apolice` WRITE;
/*!40000 ALTER TABLE `apolice` DISABLE KEYS */;
INSERT INTO `apolice` VALUES (18,8,19,3,2000.00,2,0),(23,9,24,3,2300.32,2,0),(30,12,1,3,2000.23,2,0),(32,18,1,10,3200.02,3,1),(33,18,1,2,3200.02,2,0);
/*!40000 ALTER TABLE `apolice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cobertura`
--

DROP TABLE IF EXISTS `cobertura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cobertura` (
  `CD_COBERTURA` int(11) NOT NULL AUTO_INCREMENT,
  `NM_COBERTURA` varchar(45) DEFAULT NULL,
  `DS_COBERTURA` varchar(4000) DEFAULT NULL,
  PRIMARY KEY (`CD_COBERTURA`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cobertura`
--

LOCK TABLES `cobertura` WRITE;
/*!40000 ALTER TABLE `cobertura` DISABLE KEYS */;
INSERT INTO `cobertura` VALUES (1,'Básico','COMPREENSIVA (COLISÃO, INCÊNDIO E ROUBO/FURTO) \r\nCobertura para dano parcial ou integral ao automóvel por colisão, incêndio ou roubo/furto.\r\n\r\nINCÊNDIO E ROUBO/FURTO \r\n\r\nDANOS A TERCEIROS \r\nDanos materiais: reembolso dos valores reclamados por terceiros cuja propriedade material tenha sofrido danos e danos corporais: reembolso dos valores reclamados por terceiros que tenham sofrido danos corporais (morte e/ou invalidez) ou que tenham contraído despesas médicas e hospitalares em razão do acidente.\r\n\r\nPASSAGEIROS \r\nCobre os danos corporais causados aos passageiros do veículo em razão de acidente de trânsito envolvendo o veículo segurado.'),(2,'Avançado','CARTA VERDE \r\nCarta Verde é o seguro obrigatório para veículos que ingressam em países do Mercosul. Seu objetivo é proteger terceiros afetados por acidentes de trânsito no período da viagem.\r\nPROTEÇÃO AOS VIDROS* \r\nCobertura de danos aos vidros, às lanternas, aos faróis e aos retrovisores do veículo.\r\n\r\nCARRO EXTRA \r\nGarante a locação de um veículo popular básico de 1.000 cc por até 7, 15 ou 30 dias quando acontecer um sinistro com seu automóvel.\r\n\r\nREEMBOLSO DE DESPESAS EXTRAORDINÁRIAS \r\nGarante o reembolso de despesas que você possa vir a ter em sinistro de indenização integral, até o limite máximo de reembolso.\r\n\r\nLUCROS CESSANTES \r\nPara quem utiliza o veículo para o exercício do trabalho.\r\n\r\nCARRO EXTRA PORTE MÉDIO \r\nPara quem não pode ficar sem carro em caso de sinistro e faz questão de usar um veículo com motor mais potente.\r\n\r\nSEGURO DA FRANQUIA \r\nPagamento integral da franquia no primeiro sinistro, quando os prejuízos ultrapassarem o valor da franquia estipulada na apólice. Essa cláusula poderá ser reintegrada quando for utilizada.\r\n\r\nHIGIENIZAÇÃO EM CASO DE ALAGAMENTO** \r\nGarante a limpeza do veículo em consequência de enchentes, de alagamentos ou de inundações, quando o sinistro não atingir o valor da franquia.\r\nACESSÓRIOS ');
/*!40000 ALTER TABLE `cobertura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comissao`
--

DROP TABLE IF EXISTS `comissao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comissao` (
  `CD_COMISSAO` int(11) NOT NULL AUTO_INCREMENT,
  `CD_USUARIO` int(11) NOT NULL,
  `VR_PREMIO_LIQUIDO` decimal(10,2) DEFAULT NULL,
  `VR_COMISSAO_LIQUIDO` decimal(10,2) DEFAULT NULL,
  `VR_PERC_COMISSAO` decimal(10,2) DEFAULT NULL,
  `VR_PERC_COMISSAO_LIQUIDO` decimal(10,2) DEFAULT NULL,
  `VR_PERCIR` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`CD_COMISSAO`),
  KEY `FK_COMISSAO_USUARIO_idx` (`CD_USUARIO`),
  CONSTRAINT `FK_COMISSAO_USUARIO` FOREIGN KEY (`CD_USUARIO`) REFERENCES `usuario` (`CD_USUARIO`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comissao`
--

LOCK TABLES `comissao` WRITE;
/*!40000 ALTER TABLE `comissao` DISABLE KEYS */;
INSERT INTO `comissao` VALUES (1,1,0.00,3123123.00,21321.00,21.00,2131312.00),(2,1,0.00,3123123.00,21321.00,21.00,2131312.00),(3,1,0.00,3123123.00,21321.00,21.00,2131312.00),(4,1,3232323.00,23232.00,3232.00,21.00,2323.00),(5,1,1212.00,1212.00,0.00,0.00,0.00),(6,1,1212.00,1212.00,0.00,0.00,0.00),(7,1,121.00,211.00,0.00,0.00,0.00),(8,1,3000.00,300.00,0.00,0.00,232.00),(9,1,123.00,12312.00,0.00,0.00,21.00),(10,1,231.22,233.00,0.00,0.00,21.00),(11,1,1.00,1.00,1.00,0.00,1.00),(12,1,323.23,1.00,1.00,0.00,1.00),(13,1,2323.00,2323.00,2323.00,0.00,23232.00),(14,1,3.23,2323.00,232.00,0.00,323.00),(15,1,0.00,300.23,20.00,0.00,0.00),(16,1,0.00,122.00,12.00,0.00,0.00),(17,1,0.00,233.32,14.00,0.00,0.00),(18,1,0.00,233.00,23.00,0.00,0.00),(19,1,0.00,233.00,23.00,0.00,0.00),(20,1,0.00,233.00,23.00,0.00,0.00),(21,1,0.00,233.00,23.00,0.00,0.00),(22,1,0.00,0.00,0.00,0.00,0.00),(23,1,0.00,22.00,0.00,0.00,0.00),(24,1,0.00,0.00,10.00,0.00,0.00),(25,1,0.00,0.00,15.00,0.00,0.00),(26,1,0.00,0.00,10.00,0.00,0.00),(27,1,0.00,0.00,10.00,0.00,0.00);
/*!40000 ALTER TABLE `comissao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condutor`
--

DROP TABLE IF EXISTS `condutor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `condutor` (
  `CD_CONDUTOR` int(11) NOT NULL AUTO_INCREMENT,
  `CD_SEGURADO` int(11) DEFAULT NULL,
  `CD_CPF` varchar(25) NOT NULL,
  `NM_NOME` varchar(250) NOT NULL,
  `DT_NASCIMENTO` date DEFAULT NULL,
  `IE_SEXO` int(11) DEFAULT NULL,
  `NM_ESTADOCIVIL` varchar(45) DEFAULT NULL,
  `NR_CEP` varchar(25) DEFAULT NULL,
  `IE_POSSUIOUTROSCARROS` int(11) DEFAULT NULL,
  `IE_QTDCARROS` int(11) DEFAULT NULL,
  `NR_ANOSCNH` int(11) DEFAULT NULL,
  `NM_EMAIL` varchar(300) DEFAULT NULL,
  `NM_BANCO` varchar(250) DEFAULT NULL,
  `IE_PROPRIETARIOVEICULO` int(11) DEFAULT NULL,
  `IE_RELACAOPROPRIETARIO` int(11) DEFAULT NULL,
  `IE_CONDPRINCIPAL` int(11) DEFAULT NULL,
  `IE_TIPORESIDENCIA` int(11) DEFAULT NULL,
  `DS_PROFISSAO` varchar(300) DEFAULT NULL,
  `IE_ROUBADOEM24MESES` int(11) DEFAULT NULL,
  `IE_ALGUMCONDUTORESTUDA` int(11) DEFAULT NULL,
  `IE_NOTICIASEMAIL` int(11) DEFAULT NULL,
  `IE_ITAUPERSONALITE` int(11) DEFAULT NULL,
  `IE_CARTAOPORTOSEGUROVISA` int(11) DEFAULT NULL,
  PRIMARY KEY (`CD_CONDUTOR`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condutor`
--

LOCK TABLES `condutor` WRITE;
/*!40000 ALTER TABLE `condutor` DISABLE KEYS */;
INSERT INTO `condutor` VALUES (14,0,'246.733.289-65','Caroline Laura Duarte','1985-03-07',2,'0','20.715-005',1,3,3,'rennanchagas@hotmail.com',NULL,0,0,1,1,'Professora de História',0,1,1,1,1),(15,14,'078.297.626-35','Julho Cesar Martins','1986-11-25',1,'0','20.715-005',0,0,0,NULL,NULL,1,0,0,0,NULL,0,0,0,0,0),(16,0,'173.166.212-22','Julho Martins JR','0001-01-01',1,'2','20.715-005',0,0,0,NULL,NULL,0,1,1,0,NULL,0,0,0,0,0),(17,0,'915.551.495-29','Yasmin Gourlart','1986-11-12',2,'0','20.715-005',0,0,11,'rennanchagas@hotmail.com',NULL,1,0,1,1,'CEO da Oi',1,1,1,1,1),(18,17,'736.974.118-45','Alencar Barbosa','0001-01-01',1,'0','20.715-005',0,0,0,NULL,NULL,0,0,0,0,NULL,0,0,0,0,0),(22,0,'137.335.987-09','hugo debret','2015-11-17',2,'2','20.715-005',0,0,2,'rennanchagas@hotmail.com',NULL,1,0,0,0,'chorao2',0,0,1,0,0),(23,0,'766.082.595-06','Alberto Gutão Kratz','1987-05-07',1,'3','20.715-005',0,0,20,'rennanchagas@hotmail.com',NULL,1,0,0,3,'Motorista Particular',1,1,1,1,1),(24,0,'972.325.043-81','Jessica Albaa','1985-03-04',2,'2','20.715-005',1,5,20,'rennanchagas@hotmail.com',NULL,1,0,0,3,'Atriz',1,1,1,1,1),(25,0,'214.933.141-14','Julia Andrades','1975-09-07',2,'0','20.715-005',1,3,20,'rennanchagas@hotmail.com',NULL,0,0,0,4,'Bancaria',0,1,1,1,1),(26,25,'678.662.851-60','Rodrigo Andrades','1973-02-04',1,'0','20.715-005',0,0,0,NULL,NULL,0,0,0,0,NULL,0,0,0,0,0),(27,0,'219.372.139-43','Kevin Clark Tomason','1988-10-03',1,'3','20.715-005',1,5,9,'rennanchagas@hotmail.com',NULL,1,0,1,5,'Cantor',0,0,1,1,1),(28,27,'249.010.623-60','Jason Smith Jr','0001-01-01',1,'2','20.715-005',0,0,0,NULL,NULL,0,4,0,0,NULL,0,0,0,0,0),(29,0,'274.192.743-04','Pedro Drumont','1977-10-02',1,'1','20.715-005',1,5,17,'rennanchagas@hotmail.com',NULL,1,0,0,0,'Corredor de F1',0,0,1,1,0),(30,0,'186.765.486-50','Julho Tenorio de Albuquerque','1969-02-22',1,'3','20.715-005',0,0,29,'rennanchagas@hotmail.com',NULL,1,0,0,2,'Marceneiro',0,0,0,0,0),(32,0,'379.014.695-10','João Paulo Carvalho','1987-04-09',1,'2','20.715-005',0,0,6,'rennanchagas@hotmail.com',NULL,1,0,0,0,'Gerente de marketing',0,1,1,1,0),(41,0,'593.593.378-03','Carlos Sampaio Lima','1986-06-24',1,'0','20.715-005',1,1,8,'rennanchagas@hotmail.com',NULL,1,0,0,1,'Diretor',0,0,1,1,0),(51,0,'161.405.840-78','Antônio Cunha','1965-03-17',1,'0','20.715-005',0,0,20,'rennanchagas@hotmail.com',NULL,1,0,0,2,'Taxista',0,0,1,0,1),(61,0,'715.414.128-00','Marta Pinheiro','1981-08-02',2,'0','20.715-005',0,0,9,'rennanchagas@hotmail.com',NULL,1,0,0,2,'Vendedora',0,0,1,1,0),(71,0,'423.291.658-03','Larissa Santos','1993-01-11',2,'1','20.715-005',0,0,10,'rennanchagas@hotmail.com',NULL,1,0,0,0,'Cabeleireira',1,0,1,0,1);
/*!40000 ALTER TABLE `condutor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endosso`
--

DROP TABLE IF EXISTS `endosso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endosso` (
  `CD_ENDOSSO` int(11) NOT NULL AUTO_INCREMENT,
  `CD_APOLICE` int(11) NOT NULL,
  `CD_APOLICEOLD` int(11) DEFAULT NULL,
  `DT_ENDOSSO` datetime DEFAULT NULL,
  PRIMARY KEY (`CD_ENDOSSO`),
  KEY `fk_Endosso_Apolice1_idx` (`CD_APOLICE`),
  CONSTRAINT `fk_Endosso_Apolice1` FOREIGN KEY (`CD_APOLICE`) REFERENCES `apolice` (`CD_APOLICE`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endosso`
--

LOCK TABLES `endosso` WRITE;
/*!40000 ALTER TABLE `endosso` DISABLE KEYS */;
INSERT INTO `endosso` VALUES (2,32,32,'2015-11-29 21:08:54');
/*!40000 ALTER TABLE `endosso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proposta`
--

DROP TABLE IF EXISTS `proposta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proposta` (
  `CD_PROPOSTA` int(11) NOT NULL AUTO_INCREMENT,
  `CD_CONDUTOR` int(11) NOT NULL,
  `CD_COBERTURA` int(11) DEFAULT NULL,
  `NM_MARCAVEICULO` varchar(45) DEFAULT NULL,
  `NR_ANOFABVEICULO` int(11) DEFAULT NULL,
  `NR_ANOMODELOVEICULO` int(11) DEFAULT NULL,
  `IE_ZEROKM` int(11) DEFAULT NULL,
  `NM_VEICULO` varchar(450) DEFAULT NULL,
  `IE_FINANCIADOVEICULO` int(11) DEFAULT NULL,
  `IE_TIPOVEICULO_TAXI` int(11) DEFAULT NULL,
  `IE_TIPOVEICULO_DEFICIENTE` int(11) DEFAULT NULL,
  `IE_TIPOVEICULO_KITGAS` int(11) DEFAULT NULL,
  `IE_TIPOVEICULO_BLINDADO` int(11) DEFAULT NULL,
  `IE_TIPOVEICULO_PESSOAJURIDICA` int(11) DEFAULT NULL,
  `IE_ALARMEVEICULO` int(11) DEFAULT NULL,
  `IE_TIPOESTACION` int(11) DEFAULT NULL,
  `IE_TIPOPORTAO` int(11) DEFAULT NULL,
  `NR_CEPESTACION` varchar(25) DEFAULT NULL,
  `NR_CEPDESLOC` varchar(25) DEFAULT NULL,
  `IE_UTILIZACAOVEICULO_LAZER` int(11) DEFAULT NULL,
  `IE_UTILIZACAOVEICULO_TRABALHO` int(11) DEFAULT NULL,
  `IE_UTILIZACAOVEICULO_ESTUDO` int(11) DEFAULT NULL,
  `IE_UTILIZACAOVEICULO_INSTRUMENTO` int(11) DEFAULT NULL,
  `IE_TIPOGARAGEMTRABALHO` int(11) DEFAULT NULL,
  `IE_DISTANCIATRABVEICULO` int(11) DEFAULT NULL,
  `IE_TIPOGARAGEMESTUDO` int(11) DEFAULT NULL,
  `IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA` int(11) DEFAULT NULL,
  `IE_MEDIAKMVEICULO` int(11) DEFAULT NULL,
  `IE_MOTIVO_COTACAO` int(11) DEFAULT NULL,
  `IE_PRIMEIROSEGURO` int(11) DEFAULT NULL,
  `IE_SEGUROATUAL_QUERMAISOPCOES` int(11) DEFAULT NULL,
  `IE_SEGUROATUAL_MELHORATENDIMENTO` int(11) DEFAULT NULL,
  `IE_SEGUROATUAL_NAOSATISFEITO` int(11) DEFAULT NULL,
  `NM_SEGURADORAATUAL` varchar(250) DEFAULT NULL,
  `DT_VENC_SEGUROATUAL` datetime DEFAULT NULL,
  `IE_BONUSAPOLICEATUAL_SEMSINISTRO` int(11) DEFAULT NULL,
  `IE_BONUSAPOLICEATUAL_COMSINISTRO` int(11) DEFAULT NULL,
  `NR_APOLICE` varchar(45) DEFAULT NULL,
  `NR_CI` varchar(45) DEFAULT NULL,
  `NR_PLACAVEICULO` varchar(25) DEFAULT NULL,
  `NR_CHASSIVEICULO` varchar(45) DEFAULT NULL,
  `FL_STATUS` int(11) DEFAULT '0',
  PRIMARY KEY (`CD_PROPOSTA`),
  KEY `FK_PROPOSTA_CONDUTOR_idx` (`CD_CONDUTOR`),
  KEY `FK_PROPOSTA_COBERTURA_idx` (`CD_COBERTURA`),
  CONSTRAINT `FK_PROPOSTA_COBERTURA` FOREIGN KEY (`CD_COBERTURA`) REFERENCES `cobertura` (`CD_COBERTURA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_PROPOSTA_CONDUTOR` FOREIGN KEY (`CD_CONDUTOR`) REFERENCES `condutor` (`CD_CONDUTOR`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proposta`
--

LOCK TABLES `proposta` WRITE;
/*!40000 ALTER TABLE `proposta` DISABLE KEYS */;
INSERT INTO `proposta` VALUES (8,14,2,'22',2012,2013,0,'Fusion 2.0 GTX',0,0,0,0,1,0,1,0,0,'20.715-005','20.715-005',1,1,0,0,1,2,0,0,1,0,0,0,0,0,NULL,NULL,0,0,'0','0','ahk-1224',NULL,2),(9,17,2,'6',2013,2013,0,'Audi A3 Sportback 1.4',0,0,0,0,1,1,0,1,0,'20.715-005','20.715-005',0,1,0,0,0,0,0,0,1,1,0,0,0,0,NULL,NULL,0,0,'0','0','kga-3254','vhas230kas02321',2),(12,22,1,'9',2004,2004,0,'Civic 2.0 GTS',0,0,0,1,0,0,0,0,0,'20.715-005','20.715-005',0,1,0,0,2,4,0,0,0,0,0,0,0,0,NULL,NULL,0,0,'0','0','454545',NULL,3),(16,22,2,'25',2015,2016,0,'Civic 2.0 GTS',0,0,0,1,0,0,0,0,0,'20.715-005','20.715-005',0,1,0,0,2,4,0,0,0,0,0,0,0,0,NULL,NULL,0,0,'0','0','454545',NULL,2),(17,23,1,'56',2007,2008,0,'Corolla Xei 1.8',1,1,0,1,0,0,2,1,2,'20.715-005','20.715-005',0,0,0,1,0,0,0,0,2,1,0,0,0,0,NULL,NULL,0,0,'0','0','kgb-12345','10923djvqa0131sa3',0),(18,24,2,'13',2015,2016,0,'Sandero Stepway Hi-power 1.6',1,0,0,0,0,1,3,1,2,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,1,2,0,0,1,1,'Tokio Marine','2016-03-01 00:00:00',10,3,'932934','943022','ask-29312',NULL,2),(19,25,1,'23',2015,2016,0,'Chevrolet Onix Hatch Lt 1.4 8v Flexpower 5p Mec',0,0,0,1,0,0,1,1,0,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,1,1,0,0,0,0,NULL,NULL,0,0,'0','0','sad-12391',NULL,0),(20,27,1,'13',2009,2009,0,'Citroen Xsara Picasso 2.0 Automático Prata',0,0,0,0,0,0,0,0,3,'20.715-005','20.715-005',1,1,1,1,2,3,2,1,1,1,0,0,0,0,NULL,NULL,0,0,'0','0','akc-21312',NULL,0),(21,29,2,'58',2015,2015,0,'Volvo V40 2.0 T5 R Design Turbo Gasolina 4p',0,0,0,0,0,0,0,1,0,'20.715-005','20.715-005',0,1,0,1,0,0,0,0,0,2,0,1,0,1,'AIG','2017-05-05 00:00:00',6,3,'2319412','21320','USA-29324',NULL,0),(22,30,1,'21',2000,2000,0,'Fiat Brava Sx 1.6',0,0,0,1,0,0,0,0,0,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,2,0,0,0,0,0,NULL,NULL,0,0,'0','0',NULL,NULL,0),(23,24,2,'13',2015,2016,0,'Sandero Stepway Hi-power 1.7',1,0,0,0,0,0,2,1,2,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,1,2,0,0,1,1,'Tokio Marine','2016-03-01 00:00:00',10,3,'932934','943022','ask-29312',NULL,2),(24,24,2,'13',2015,2016,0,'Sandero Stepway Hi-power 1.6',1,0,0,0,0,1,3,1,2,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,1,2,0,0,1,1,'Tokio Marine','2016-03-01 00:00:00',10,3,'932934','943022','ask-29312',NULL,2),(32,32,1,'21',2003,2004,0,'Palio',0,0,0,1,0,0,0,0,1,'20.715-005','20.715-005',1,1,0,0,1,1,0,0,1,1,0,0,0,0,NULL,NULL,0,0,'0','0','Kst3268','1D46P25B038108775',0),(41,41,2,'7',2015,2016,0,'Coupé',0,0,0,0,1,0,1,0,0,'20.715-005','20.715-005',1,1,0,0,1,0,0,0,1,1,0,0,0,0,NULL,NULL,0,0,'0','0','Htv4287','1D46P25B038108776',0),(51,51,1,'22',2006,2007,0,'Fiesta',2,1,0,0,0,0,0,0,1,'20.715-005','20.715-005',0,1,0,0,3,4,0,0,2,0,0,1,1,0,NULL,NULL,0,0,'0','0','Jhk7689','1D46P25B038108777',0),(61,61,2,'25',2010,2010,1,'Civic',1,0,1,0,0,0,0,0,1,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,0,0,0,0,0,0,NULL,NULL,0,0,'0','0','Tvc1541','1D46P25B038108778',0),(71,71,1,'26',2013,2013,0,'HB20',0,0,1,0,0,0,1,0,1,'20.715-005','20.715-005',1,0,0,0,0,0,0,0,0,1,0,0,0,0,NULL,NULL,0,0,'0','0','Ksp3259','1D46P25B038108771',0);
/*!40000 ALTER TABLE `proposta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seguradora`
--

DROP TABLE IF EXISTS `seguradora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seguradora` (
  `CD_SEGURADORA` int(11) NOT NULL AUTO_INCREMENT,
  `NM_SEGURADORA` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`CD_SEGURADORA`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seguradora`
--

LOCK TABLES `seguradora` WRITE;
/*!40000 ALTER TABLE `seguradora` DISABLE KEYS */;
INSERT INTO `seguradora` VALUES (1,'Tokio Marine'),(2,'Azul Seguros'),(3,'Allianz'),(4,'Liberty Seguros'),(5,'Porto Seguro'),(6,'HDI Seguros'),(7,'Mitsui Sumitomo Seguros'),(8,'AIG Seguros'),(9,'Mapfre Seguros'),(10,'Bradesco Seguradora'),(11,'Itaú Seguros'),(12,'Chubb Seguros'),(13,'Yasuda Marítima Seguros');
/*!40000 ALTER TABLE `seguradora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefone`
--

DROP TABLE IF EXISTS `telefone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefone` (
  `CD_TELEFONE` int(11) NOT NULL AUTO_INCREMENT,
  `CD_CONDUTOR` int(11) NOT NULL,
  `NR_TELEFONE` varchar(45) NOT NULL,
  PRIMARY KEY (`CD_TELEFONE`,`CD_CONDUTOR`),
  KEY `FK_TELEFONE_PESSOA_idx` (`CD_CONDUTOR`),
  CONSTRAINT `FK_TELEFONE_CONDUTOR` FOREIGN KEY (`CD_CONDUTOR`) REFERENCES `condutor` (`CD_CONDUTOR`)
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefone`
--

LOCK TABLES `telefone` WRITE;
/*!40000 ALTER TABLE `telefone` DISABLE KEYS */;
INSERT INTO `telefone` VALUES (10,14,'(21) 3233-23232'),(11,17,'(21) 3443-22131'),(12,23,'(12) 3123-31232'),(13,24,'(21) 4930-92322'),(14,25,'(12) 3432-23423'),(15,25,'(12) 3123-12323'),(16,25,'(32) 1232-32131'),(17,27,'(21) 4324-22123'),(18,27,'(12) 1231-31231'),(19,29,'(21) 9093-42402'),(20,30,'(21) 4032-04234'),(21,30,'(12) 3123-12312'),(22,32,'(21) 3047-5263_'),(31,41,'(21) 3098-4537_'),(41,51,'(21) 3098-4537_'),(51,61,'(21) 3098-4537_'),(61,71,'(21) 3098-4537_');
/*!40000 ALTER TABLE `telefone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `CD_USUARIO` int(11) NOT NULL AUTO_INCREMENT,
  `NM_USUARIO` varchar(250) NOT NULL,
  `NM_NOME` varchar(250) NOT NULL,
  `NM_SENHA` varchar(45) NOT NULL,
  `FL_PERMISSAO` int(10) unsigned zerofill NOT NULL,
  PRIMARY KEY (`CD_USUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'rennanchagas@hotmail.com','Rennan Chagas','123',0000000002),(2,'brunodouat@gmail.com','Bruno Douat','123',0000000002),(3,'alinedefatima06@gmail.com','Aline Silva Da Silva','123',0000000002),(4,'rennanchagas@outlook.com','Rennan Franco Chagas','123',0000000001);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `valorproposta`
--

DROP TABLE IF EXISTS `valorproposta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `valorproposta` (
  `CD_VALORPROPOSTA` int(11) NOT NULL AUTO_INCREMENT,
  `CD_CONDUTOR` int(11) NOT NULL,
  `CD_APOLICE` int(11) NOT NULL,
  `DS_DESCRICAO` varchar(450) DEFAULT NULL,
  `DS_TIPO` int(11) DEFAULT '0',
  `DT_DATA_VENCIMENTO` datetime DEFAULT NULL,
  `VL_VALOR` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`CD_VALORPROPOSTA`),
  KEY `FK_PAGAMENTO_APOLICE_idx` (`CD_APOLICE`),
  KEY `FK_VALORPROPOSTA_CONDUTOR_idx` (`CD_CONDUTOR`),
  CONSTRAINT `FK_VALORPROPOSTA_CONDUTOR` FOREIGN KEY (`CD_CONDUTOR`) REFERENCES `condutor` (`CD_CONDUTOR`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_VALORPROSTA_APOLICE` FOREIGN KEY (`CD_APOLICE`) REFERENCES `apolice` (`CD_APOLICE`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `valorproposta`
--

LOCK TABLES `valorproposta` WRITE;
/*!40000 ALTER TABLE `valorproposta` DISABLE KEYS */;
INSERT INTO `valorproposta` VALUES (13,14,18,NULL,0,'2015-10-10 00:00:00',2000.00),(16,17,23,NULL,1,'2015-10-10 00:00:00',2300.32);
/*!40000 ALTER TABLE `valorproposta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-29 22:25:24
