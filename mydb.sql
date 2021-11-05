-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Институты`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Институты` (
  `Институты_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Название` VARCHAR(255) NOT NULL,
  `Декан` VARCHAR(255) NULL,
  PRIMARY KEY (`Институты_id`),
  UNIQUE INDEX `inst_id_UNIQUE` (`Институты_id` ASC),
  UNIQUE INDEX `name_UNIQUE` (`Название` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Кафедры`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Кафедры` (
  `Кафедры_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Шифр` VARCHAR(8) NOT NULL,
  `Название` VARCHAR(255) NOT NULL,
  `Заведующий` VARCHAR(255) NULL,
  `Институты_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Кафедры_id`),
  UNIQUE INDEX `dep_id_UNIQUE` (`Кафедры_id` ASC),
  INDEX `fk_department_institute1_idx` (`Институты_id` ASC),
  UNIQUE INDEX `shortname_UNIQUE` (`Шифр` ASC),
  UNIQUE INDEX `name_UNIQUE` (`Название` ASC),
  CONSTRAINT `fk_department_institute1`
    FOREIGN KEY (`Институты_id`)
    REFERENCES `mydb`.`Институты` (`Институты_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Специальности`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Специальности` (
  `Специальности_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Шифр` VARCHAR(8) NOT NULL,
  `Название` VARCHAR(255) NOT NULL,
  `Кафедры_id` INT UNSIGNED NULL,
  `Количество_курсов` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`Специальности_id`),
  UNIQUE INDEX `spec_id_UNIQUE` (`Специальности_id` ASC),
  INDEX `fk_speciality_department1_idx` (`Кафедры_id` ASC),
  CONSTRAINT `fk_speciality_department1`
    FOREIGN KEY (`Кафедры_id`)
    REFERENCES `mydb`.`Кафедры` (`Кафедры_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Формы_обучения`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Формы_обучения` (
  `Формы_обучения_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Тип` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Формы_обучения_id`),
  UNIQUE INDEX `edu_t_id_UNIQUE` (`Формы_обучения_id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Кураторы`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Кураторы` (
  `Кураторы_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `ФИО` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Кураторы_id`),
  UNIQUE INDEX `curator_id_UNIQUE` (`Кураторы_id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Группы`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Группы` (
  `Группы_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Курс` INT UNSIGNED NOT NULL,
  `Поток` VARCHAR(4) NOT NULL,
  `Номер` VARCHAR(10) NOT NULL,
  `Специальности_id` INT UNSIGNED NOT NULL,
  `Кураторы_id` INT UNSIGNED NULL,
  `Формы_обучения_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Группы_id`),
  UNIQUE INDEX `group_num_UNIQUE` (`Группы_id` ASC),
  INDEX `fk_group_speciality1_idx` (`Специальности_id` ASC),
  INDEX `fk_groupp_edu_type1_idx` (`Формы_обучения_id` ASC),
  INDEX `fr_groupp_curator_idx` (`Кураторы_id` ASC),
  UNIQUE INDEX `Номер_UNIQUE` (`Номер` ASC),
  CONSTRAINT `fk_group_speciality1`
    FOREIGN KEY (`Специальности_id`)
    REFERENCES `mydb`.`Специальности` (`Специальности_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_groupp_edu_type1`
    FOREIGN KEY (`Формы_обучения_id`)
    REFERENCES `mydb`.`Формы_обучения` (`Формы_обучения_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fr_groupp_curator`
    FOREIGN KEY (`Кураторы_id`)
    REFERENCES `mydb`.`Кураторы` (`Кураторы_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Формы_оплаты_обучения`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Формы_оплаты_обучения` (
  `Формы_оплаты_обучения_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Цена` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Формы_оплаты_обучения_id`),
  UNIQUE INDEX `edu_id_UNIQUE` (`Формы_оплаты_обучения_id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Студенты`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Студенты` (
  `Студенты_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `ФИО` VARCHAR(255) NOT NULL,
  `Пол` VARCHAR(1) NOT NULL,
  `Номер_телефона` VARCHAR(16) NOT NULL,
  `Адрес` VARCHAR(255) NOT NULL,
  `Дата_рождения` DATE NOT NULL,
  `Группы_id` INT UNSIGNED NULL,
  `Формы_оплаты_обучения_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Студенты_id`),
  UNIQUE INDEX `stud_code_UNIQUE` (`Студенты_id` ASC),
  INDEX `fk_student_group1_idx` (`Группы_id` ASC),
  UNIQUE INDEX `phone_number_UNIQUE` (`Номер_телефона` ASC),
  INDEX `fk_student_edu_price1_idx` (`Формы_оплаты_обучения_id` ASC),
  CONSTRAINT `fk_student_group1`
    FOREIGN KEY (`Группы_id`)
    REFERENCES `mydb`.`Группы` (`Группы_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_student_edu_price1`
    FOREIGN KEY (`Формы_оплаты_обучения_id`)
    REFERENCES `mydb`.`Формы_оплаты_обучения` (`Формы_оплаты_обучения_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Кандидаты_на_исключение`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Кандидаты_на_исключение` (
  `Кандидаты_на_исключение_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Студенты_id` INT UNSIGNED NOT NULL,
  `Причина` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Кандидаты_на_исключение_id`),
  UNIQUE INDEX `Кандидаты_на_исключение_id_UNIQUE` (`Кандидаты_на_исключение_id` ASC),
  CONSTRAINT `fk_to_expelled_student`
    FOREIGN KEY (`Студенты_id`)
    REFERENCES `mydb`.`Студенты` (`Студенты_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Дисциплины`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Дисциплины` (
  `Дисциплины_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Название` VARCHAR(255) NOT NULL,
  `Кафедры_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Дисциплины_id`),
  UNIQUE INDEX `subject_id_UNIQUE` (`Дисциплины_id` ASC),
  INDEX `fk_subject_department1_idx` (`Кафедры_id` ASC),
  UNIQUE INDEX `name_UNIQUE` (`Название` ASC),
  CONSTRAINT `fk_subject_department1`
    FOREIGN KEY (`Кафедры_id`)
    REFERENCES `mydb`.`Кафедры` (`Кафедры_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Посещаемость`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Посещаемость` (
  `Посещаемость_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Студенты_id` INT UNSIGNED NOT NULL,
  `Дисциплины_id` INT UNSIGNED NOT NULL,
  `Семестр` INT UNSIGNED NOT NULL,
  `Пары_лекций` INT UNSIGNED NULL,
  `Пары_семинаров` INT UNSIGNED NULL,
  PRIMARY KEY (`Посещаемость_id`),
  UNIQUE INDEX `sub_at_id_UNIQUE` (`Посещаемость_id` ASC),
  INDEX `fk_subject_attendance_subject1_idx` (`Дисциплины_id` ASC),
  INDEX `fk_subject_attendance_student1_idx` (`Студенты_id` ASC),
  CONSTRAINT `fk_subject_attendance_subject1`
    FOREIGN KEY (`Дисциплины_id`)
    REFERENCES `mydb`.`Дисциплины` (`Дисциплины_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_subject_attendance_student1`
    FOREIGN KEY (`Студенты_id`)
    REFERENCES `mydb`.`Студенты` (`Студенты_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Формы_контроля`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Формы_контроля` (
  `Формы_контроля_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Тип` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Формы_контроля_id`),
  UNIQUE INDEX `con_form_id_UNIQUE` (`Формы_контроля_id` ASC),
  UNIQUE INDEX `type_UNIQUE` (`Тип` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Учебные_планы`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Учебные_планы` (
  `Учебные_планы_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Пары_лекций` INT UNSIGNED NULL,
  `Пары_семинаров` INT UNSIGNED NULL,
  `Семестр` INT UNSIGNED NOT NULL,
  `Курсовая` VARCHAR(10) NOT NULL,
  `Дисциплины_id` INT UNSIGNED NOT NULL,
  `Специальности_id` INT UNSIGNED NOT NULL,
  `Формы_контроля_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Учебные_планы_id`),
  UNIQUE INDEX `plan_id_UNIQUE` (`Учебные_планы_id` ASC),
  INDEX `fk_edu_plan_subject1_idx` (`Дисциплины_id` ASC),
  INDEX `fk_edu_plan_speciality1_idx` (`Специальности_id` ASC),
  INDEX `fk_edu_plan_control_form1_idx` (`Формы_контроля_id` ASC),
  CONSTRAINT `fk_edu_plan_subject1`
    FOREIGN KEY (`Дисциплины_id`)
    REFERENCES `mydb`.`Дисциплины` (`Дисциплины_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_edu_plan_speciality1`
    FOREIGN KEY (`Специальности_id`)
    REFERENCES `mydb`.`Специальности` (`Специальности_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_edu_plan_control_form1`
    FOREIGN KEY (`Формы_контроля_id`)
    REFERENCES `mydb`.`Формы_контроля` (`Формы_контроля_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Оценки`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Оценки` (
  `Оценки_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Результат` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Оценки_id`),
  UNIQUE INDEX `grade_id_UNIQUE` (`Оценки_id` ASC),
  UNIQUE INDEX `point_UNIQUE` (`Результат` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Успеваемость`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Успеваемость` (
  `Успеваемость_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Студенты_id` INT UNSIGNED NOT NULL,
  `Посещаемость_id` INT UNSIGNED NULL,
  `Учебные_планы_id` INT UNSIGNED NULL,
  `Оценки_id` INT UNSIGNED NULL,
  `Формы_контроля_id` INT UNSIGNED NULL,
  PRIMARY KEY (`Успеваемость_id`),
  UNIQUE INDEX `grade_id_UNIQUE` (`Успеваемость_id` ASC),
  INDEX `fk_grade_stud_subject_attendance1_idx` (`Посещаемость_id` ASC),
  INDEX `fk_grade_stud_student1_idx` (`Студенты_id` ASC),
  INDEX `fk_grade_stud_grade1_idx` (`Оценки_id` ASC),
  INDEX `fk_grade_stud_control_form1_idx` (`Формы_контроля_id` ASC),
  UNIQUE INDEX `dis_at_id_UNIQUE` (`Посещаемость_id` ASC),
  INDEX `fk_Успеваемость_Учебные_планы1_idx` (`Учебные_планы_id` ASC),
  CONSTRAINT `fk_grade_stud_subject_attendance1`
    FOREIGN KEY (`Посещаемость_id`)
    REFERENCES `mydb`.`Посещаемость` (`Посещаемость_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_grade_stud_student1`
    FOREIGN KEY (`Студенты_id`)
    REFERENCES `mydb`.`Студенты` (`Студенты_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_grade_stud_grade1`
    FOREIGN KEY (`Оценки_id`)
    REFERENCES `mydb`.`Оценки` (`Оценки_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_grade_stud_control_form1`
    FOREIGN KEY (`Формы_контроля_id`)
    REFERENCES `mydb`.`Формы_контроля` (`Формы_контроля_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Успеваемость_Учебные_планы1`
    FOREIGN KEY (`Учебные_планы_id`)
    REFERENCES `mydb`.`Учебные_планы` (`Учебные_планы_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Курсовые`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Курсовые` (
  `Курсовые_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Тема` VARCHAR(255) NOT NULL,
  `Курс` INT UNSIGNED NOT NULL,
  `Студенты_id` INT UNSIGNED NOT NULL,
  `Оценки_id` INT UNSIGNED NULL,
  `Дисциплины_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`Курсовые_id`),
  UNIQUE INDEX `coursework_id_UNIQUE` (`Курсовые_id` ASC),
  INDEX `fk_coursework_student1_idx` (`Студенты_id` ASC),
  INDEX `fk_coursework_grade1_idx` (`Оценки_id` ASC),
  INDEX `fk_coursework_discipline1_idx` (`Дисциплины_id` ASC),
  CONSTRAINT `fk_coursework_student1`
    FOREIGN KEY (`Студенты_id`)
    REFERENCES `mydb`.`Студенты` (`Студенты_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_coursework_grade1`
    FOREIGN KEY (`Оценки_id`)
    REFERENCES `mydb`.`Оценки` (`Оценки_id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_coursework_discipline1`
    FOREIGN KEY (`Дисциплины_id`)
    REFERENCES `mydb`.`Дисциплины` (`Дисциплины_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Академические_задолженности`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Академические_задолженности` (
  `Академические_задолженности_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Студенты_id` INT UNSIGNED NOT NULL,
  `Дисциплины_id` INT UNSIGNED NULL,
  `Дата_появления` DATE NOT NULL,
  `Тип_задолженности` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`Академические_задолженности_id`),
  UNIQUE INDEX `a_d_id_UNIQUE` (`Академические_задолженности_id` ASC),
  INDEX `fk_academic_debt_subject1_idx` (`Дисциплины_id` ASC),
  INDEX `fk_academic_debt_student1_idx` (`Студенты_id` ASC),
  CONSTRAINT `fk_academic_debt_subject1`
    FOREIGN KEY (`Дисциплины_id`)
    REFERENCES `mydb`.`Дисциплины` (`Дисциплины_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_academic_debt_student1`
    FOREIGN KEY (`Студенты_id`)
    REFERENCES `mydb`.`Студенты` (`Студенты_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `mydb`.`Институты`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Институты` (`Институты_id`, `Название`, `Декан`) VALUES (1, 'Институт информационных технологий', 'Тимошенко. Н. А.');
INSERT INTO `mydb`.`Институты` (`Институты_id`, `Название`, `Декан`) VALUES (2, 'Институт комплексной безопасности и специального приборостроения', 'Кудж М.Н.');
INSERT INTO `mydb`.`Институты` (`Институты_id`, `Название`, `Декан`) VALUES (3, 'Институт радиотехнических и телекоммуникационных систем', 'Васильев А.Г.');
INSERT INTO `mydb`.`Институты` (`Институты_id`, `Название`, `Декан`) VALUES (4, 'Физико-технологический институт', 'Шамин Р.В.');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Кафедры`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (1, 'КБ-2', 'Прикладные информационные технологии', 'Русаков М.М.', 2);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (2, 'КБ-4', 'Интеллектуальные системы информационной безопасности', 'Магомедов Ш.Г.', 2);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (3, 'ПМ-1', 'Прикладная математика', 'Чувикова О.Л.', 1);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (4, 'ВТ-1', 'Вычислительная техника', 'Лисицын Н.Е.', 1);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (5, 'ВМ-2', 'Высшая математика-2', 'Чекалкин Н.С.', 4);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (6, 'Ф-1', 'Физика', 'Задерновский А.А.', 4);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (7, 'ИГ-1', 'Инженерная графика', 'Вышнепольский В.И.', 3);
INSERT INTO `mydb`.`Кафедры` (`Кафедры_id`, `Шифр`, `Название`, `Заведующий`, `Институты_id`) VALUES (8, 'ГС-1', 'Геоинформатические системы', 'Карпов Д.А.', 3);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Специальности`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Специальности` (`Специальности_id`, `Шифр`, `Название`, `Кафедры_id`, `Количество_курсов`) VALUES (1, '09.03.02', 'ИИ и Т', 1, 4);
INSERT INTO `mydb`.`Специальности` (`Специальности_id`, `Шифр`, `Название`, `Кафедры_id`, `Количество_курсов`) VALUES (2, '09.03.04', 'ПИ', 1, 4);
INSERT INTO `mydb`.`Специальности` (`Специальности_id`, `Шифр`, `Название`, `Кафедры_id`, `Количество_курсов`) VALUES (3, '09.03.02', 'ИИ и Т', 2, 4);
INSERT INTO `mydb`.`Специальности` (`Специальности_id`, `Шифр`, `Название`, `Кафедры_id`, `Количество_курсов`) VALUES (4, '10.05.05', 'БИТП', 2, 4);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Формы_обучения`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Формы_обучения` (`Формы_обучения_id`, `Тип`) VALUES (1, 'Очно');
INSERT INTO `mydb`.`Формы_обучения` (`Формы_обучения_id`, `Тип`) VALUES (2, 'Очно-заочно');
INSERT INTO `mydb`.`Формы_обучения` (`Формы_обучения_id`, `Тип`) VALUES (3, 'Заочно');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Кураторы`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Кураторы` (`Кураторы_id`, `ФИО`) VALUES (1, 'Русаков А.М.');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Группы`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Группы` (`Группы_id`, `Курс`, `Поток`, `Номер`, `Специальности_id`, `Кураторы_id`, `Формы_обучения_id`) VALUES (1, 1, '2020', 'БСБО-01-20', 1, 1, 1);
INSERT INTO `mydb`.`Группы` (`Группы_id`, `Курс`, `Поток`, `Номер`, `Специальности_id`, `Кураторы_id`, `Формы_обучения_id`) VALUES (2, 2, '2019', 'БСБО-02-19', 1, NULL, 1);
INSERT INTO `mydb`.`Группы` (`Группы_id`, `Курс`, `Поток`, `Номер`, `Специальности_id`, `Кураторы_id`, `Формы_обучения_id`) VALUES (3, 1, '2020', 'БСБО-02-20', 1, 1, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Формы_оплаты_обучения`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Формы_оплаты_обучения` (`Формы_оплаты_обучения_id`, `Цена`) VALUES (1, '0');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Студенты`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Студенты` (`Студенты_id`, `ФИО`, `Пол`, `Номер_телефона`, `Адрес`, `Дата_рождения`, `Группы_id`, `Формы_оплаты_обучения_id`) VALUES (1, 'Видякин И.Н.', 'М', '+7-963-672-11-23', 'г.Москва', '2020-05-27', 1, 1);
INSERT INTO `mydb`.`Студенты` (`Студенты_id`, `ФИО`, `Пол`, `Номер_телефона`, `Адрес`, `Дата_рождения`, `Группы_id`, `Формы_оплаты_обучения_id`) VALUES (2, 'Газарова П.В.', 'Ж', 'Секрет', 'г.Москва', '2020-01-01', 1, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Дисциплины`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (1, 'Английский', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (2, 'Аис', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (3, 'Линал', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (4, 'Матан', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (5, 'Тп', 2);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (6, 'Дискрет', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (7, 'Физика', 3);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (8, 'Физра', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (9, 'Экономика', 1);
INSERT INTO `mydb`.`Дисциплины` (`Дисциплины_id`, `Название`, `Кафедры_id`) VALUES (10, 'Право', 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Посещаемость`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Посещаемость` (`Посещаемость_id`, `Студенты_id`, `Дисциплины_id`, `Семестр`, `Пары_лекций`, `Пары_семинаров`) VALUES (1, 1, 1, 1, 5, 10);
INSERT INTO `mydb`.`Посещаемость` (`Посещаемость_id`, `Студенты_id`, `Дисциплины_id`, `Семестр`, `Пары_лекций`, `Пары_семинаров`) VALUES (2, 1, 2, 1, 10, 12);
INSERT INTO `mydb`.`Посещаемость` (`Посещаемость_id`, `Студенты_id`, `Дисциплины_id`, `Семестр`, `Пары_лекций`, `Пары_семинаров`) VALUES (3, 2, 1, 1, 5, 10);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Формы_контроля`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Формы_контроля` (`Формы_контроля_id`, `Тип`) VALUES (1, 'Экзамен');
INSERT INTO `mydb`.`Формы_контроля` (`Формы_контроля_id`, `Тип`) VALUES (2, 'Зачёт');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Учебные_планы`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Учебные_планы` (`Учебные_планы_id`, `Пары_лекций`, `Пары_семинаров`, `Семестр`, `Курсовая`, `Дисциплины_id`, `Специальности_id`, `Формы_контроля_id`) VALUES (1, 10, 25, 1, 'Нет', 1, 1, 1);
INSERT INTO `mydb`.`Учебные_планы` (`Учебные_планы_id`, `Пары_лекций`, `Пары_семинаров`, `Семестр`, `Курсовая`, `Дисциплины_id`, `Специальности_id`, `Формы_контроля_id`) VALUES (2, 10, 15, 1, 'Нет', 2, 1, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Оценки`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (1, 'Незачёт');
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (2, 'Зачёт');
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (3, '2');
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (4, '3');
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (5, '4');
INSERT INTO `mydb`.`Оценки` (`Оценки_id`, `Результат`) VALUES (6, '5');

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Успеваемость`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Успеваемость` (`Успеваемость_id`, `Студенты_id`, `Посещаемость_id`, `Учебные_планы_id`, `Оценки_id`, `Формы_контроля_id`) VALUES (1, 1, 1, 1, 5, 1);
INSERT INTO `mydb`.`Успеваемость` (`Успеваемость_id`, `Студенты_id`, `Посещаемость_id`, `Учебные_планы_id`, `Оценки_id`, `Формы_контроля_id`) VALUES (2, 2, 3, 1, 5, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `mydb`.`Курсовые`
-- -----------------------------------------------------
START TRANSACTION;
USE `mydb`;
INSERT INTO `mydb`.`Курсовые` (`Курсовые_id`, `Тема`, `Курс`, `Студенты_id`, `Оценки_id`, `Дисциплины_id`) VALUES (1, 'БД', 2, 1, NULL, 3);
INSERT INTO `mydb`.`Курсовые` (`Курсовые_id`, `Тема`, `Курс`, `Студенты_id`, `Оценки_id`, `Дисциплины_id`) VALUES (2, 'Реестр', 1, 2, NULL, 3);

COMMIT;

