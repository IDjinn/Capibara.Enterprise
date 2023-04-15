-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.5.16-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT = @@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE = @@TIME_ZONE */;
/*!40103 SET TIME_ZONE = '+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS = @@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS = 0 */;
/*!40101 SET @OLD_SQL_MODE = @@SQL_MODE, SQL_MODE = 'NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES = @@SQL_NOTES, SQL_NOTES = 0 */;

-- Copiando estrutura para tabela capibara.rooms
CREATE TABLE IF NOT EXISTS `rooms`
(
    `Id` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = armscii8
  COLLATE = armscii8_bin;

-- Copiando dados para a tabela capibara.rooms: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela capibara.room_items
CREATE TABLE IF NOT EXISTS `room_items`
(
    `room_id`      smallint(5) unsigned NOT NULL DEFAULT 0,
    `chunk_index`  bigint(20) unsigned  NOT NULL DEFAULT 0,
    `item_id`      int(10) unsigned     NOT NULL DEFAULT 0,
    `coords_index` int(10) unsigned     NOT NULL DEFAULT 0,
    `x`            int(10) unsigned     NOT NULL DEFAULT 0,
    `y`            int(10) unsigned     NOT NULL DEFAULT 0,
    `z`            double               NOT NULL DEFAULT 0,
    `state`        text COLLATE armscii8_bin     DEFAULT NULL
) ENGINE = InnoDB
  DEFAULT CHARSET = armscii8
  COLLATE = armscii8_bin;

-- Copiando dados para a tabela capibara.room_items: ~0 rows (aproximadamente)
INSERT INTO `room_items` (`room_id`, `chunk_index`, `item_id`, `coords_index`, `x`, `y`, `z`, `state`)
VALUES (10, 15, 0, 0, 0, 0, 0, NULL);

/*!40103 SET TIME_ZONE = IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE = IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS = IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT = @OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES = IFNULL(@OLD_SQL_NOTES, 1) */;
