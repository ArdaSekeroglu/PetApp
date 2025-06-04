DROP DATABASE IF EXISTS petapp;
CREATE DATABASE petapp CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE petapp;

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    surname VARCHAR(50) NOT NULL,
    account_name VARCHAR(50) NOT NULL,
    password CHAR(64) NOT NULL,
    eposta VARCHAR(100) NOT NULL,
    phone_no VARCHAR(20),
    image_data LONGBLOB
);

CREATE TABLE species (
    species_id INT AUTO_INCREMENT PRIMARY KEY,
    species_name VARCHAR(50) NOT NULL
);

CREATE TABLE breeds (
    breed_id INT AUTO_INCREMENT PRIMARY KEY,
    species_id INT,
    breed_name VARCHAR(50),
    FOREIGN KEY (species_id) REFERENCES species(species_id)
);

CREATE TABLE pets (
    pet_id INT AUTO_INCREMENT PRIMARY KEY,
    pOwner INT,
    pName VARCHAR(50),
    pAge INT,
    gender VARCHAR(15),
    species_id INT,
    breed_id INT,
    pet_images LONGBLOB,
    FOREIGN KEY (pOwner) REFERENCES users(user_id),
    FOREIGN KEY (species_id) REFERENCES species(species_id),
    FOREIGN KEY (breed_id) REFERENCES breeds(breed_id)
);

CREATE TABLE care_dog_cat (
    care_id INT AUTO_INCREMENT PRIMARY KEY,
    pet_id INT,
    food DATETIME,
    food_interval_hours INT,
    water DATETIME,
    water_interval_hours INT,
    fur DATETIME,
    fur_interval_hours INT,
    nail DATETIME,
    nail_interval_hours INT,
    toilet_clean DATETIME,
    toilet_clean_interval_hours INT,
    neutered BOOLEAN,
    daily_exercise DATETIME,
    daily_exercise_interval_hours INT,
    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);

CREATE TABLE care_fish (
    care_id INT AUTO_INCREMENT PRIMARY KEY,
    pet_id INT,
    food DATETIME,
    food_interval_hours INT,
    lastWaterChange DATETIME,
    lastWaterChange_interval_hours INT,
    temperature DATETIME,
    temperature_interval_hours INT,
    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);

CREATE TABLE care_reptile_spider (
    care_id INT AUTO_INCREMENT PRIMARY KEY,
    pet_id INT,
    food DATETIME,
    food_interval_hours INT,
    water DATETIME,
    water_interval_hours INT,
    temperature DATETIME,
    temperature_interval_hours INT,
    humidityLevel DATETIME,
    humidityLevel_interval_hours INT,
    dateOfMoltedRecently DATETIME,
    dateOfMoltedRecently_interval_hours INT,
    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);

CREATE TABLE care_bird (
    care_id INT AUTO_INCREMENT PRIMARY KEY,
    pet_id INT,
    food DATETIME,
    food_interval_hours INT,
    water DATETIME,
    water_interval_hours INT,
    cage_cleaned DATETIME,
    cage_cleaned_interval_hours INT,
    talk_progress DATETIME,
    talk_progress_interval_hours INT,
    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);

CREATE TABLE note_section (
    note_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    pet_id INT,
    note TEXT NOT NULL,
    header VARCHAR(300) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);


CREATE TABLE note_reminders (
    reminder_id INT AUTO_INCREMENT PRIMARY KEY,
    note_id INT NOT NULL,
    reminder_time DATETIME NOT NULL,
    is_triggered BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (note_id) REFERENCES note_section(note_id) ON DELETE CASCADE
);


INSERT INTO species (species_name) 
VALUES ('Kedi'), ('Köpek'), ('Kuş'), ('Balık'), ('Yılan'), ('Örümcek');
