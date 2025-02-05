create database CourseWork;
go

USE CourseWork;
go

create table CPU (
	ID_cpu int primary key identity(1,1),
	cpu_brand nvarchar(50) not null,
	cpu_model nvarchar(50) not null,
	cpu_frequency decimal(5, 2) not null,
	cpu_cores int not null,
	cpu_threads int not null,
	cpu_price decimal(10, 2)  not null
);


create table GPU (
	ID_gpu int primary key identity(1, 1),
	gpu_brand nvarchar(50) not null,
	gpu_model nvarchar(50) not null,
	gpu_memorySize int not null,
	gpu_frequency decimal(5, 2) not null,
	gpu_price decimal(10, 2) not null
);


create table RAM (
	ID_ram int primary key identity(1, 1),
	ram_brand nvarchar(50) not null,
	ram_model nvarchar(50) not null,
	ram_memorySize int not null,
	ram_frequency decimal(5, 2) not null,
	ram_price decimal(10, 2) not null
);

create table Storage (	
	ID_storage int primary key identity(1, 1),
	storage_brand nvarchar(50) not null,
	storage_model nvarchar(50) not null,
	storage_type nvarchar(50) not null,
	storage_capacity int not null,
	storage_price decimal(10, 2) not null
);

create table PowerSup (
	ID_powerSup int primary key identity(1, 1),
	powerSup_brand nvarchar(50) not null,
	powerSup_model nvarchar(50) not null,
	powerSup_powerWatt int not null,
	powerSup_efficincy nvarchar(50) not null,
	powerSup_price decimal(10, 2) not null
);

create table Mboard (
	ID_mboard int primary key identity(1, 1),
	mboard_brand nvarchar(50) not null,
	mboard_model nvarchar(50) not null,
	mboard_socket nvarchar(50) not null,
	mboard_chipset nvarchar(50) not null,
	mboard_formFactor nvarchar(50) not null,
	mboard_price decimal(10, 2) not null
);

create table cCase(
	ID_case int primary key identity(1, 1),
	case_brand nvarchar(50) not null,
	case_model nvarchar(50) not null,
	case_formFactor nvarchar(50) not null,
	case_prise decimal(10, 2) not null
);

alter table RAM
add ram_type nvarchar(50) not null;

insert into CPU (cpu_brand, cpu_model, cpu_frequency, cpu_cores, cpu_threads, cpu_price)
values
('Intel', 'Core i7-11700K', 3.6, 8, 16, 350.00),
('AMD', 'Ryzen 5 5600X', 3.7, 6, 12, 299.00),
('Intel', 'Core i5-12600K', 3.7, 10, 16, 319.00),
('AMD', 'Ryzen 7 5800X', 3.8, 8, 16, 449.00),
('Intel', 'Core i9-12900K', 3.2, 16, 24, 599.00),
('AMD', 'Ryzen 9 5950X', 3.4, 16, 32, 749.00),
('Intel', 'Core i3-10100F', 3.6, 4, 8, 129.00),
('AMD', 'Ryzen 3 3100', 3.6, 4, 8, 99.00),
('Intel', 'Pentium Gold G6400', 4.0, 2, 4, 64.00),
('AMD', 'Athlon 3000G', 3.5, 2, 4, 49.00),
('Intel', 'Core i9-11900KF', 3.5, 8, 16, 399.00),
('AMD', 'Ryzen 5 3600', 3.6, 6, 12, 199.00),
('Intel', 'Core i7-10700', 2.9, 8, 16, 323.00),
('AMD', 'Ryzen 7 3700X', 3.6, 8, 16, 329.00),
('Intel', 'Core i5-10400F', 2.9, 6, 12, 157.00);

insert into GPU (gpu_brand, gpu_model, gpu_memorySize, gpu_frequency, gpu_price)
values
('NVIDIA', 'GeForce RTX 3080', 10240, 1.71, 699.99),
('AMD', 'Radeon RX 6800 XT', 16384, 2.25, 649.99),
('NVIDIA', 'GeForce RTX 3070', 8192, 1.73, 499.99),
('AMD', 'Radeon RX 6700 XT', 12288, 2.42, 479.99),
('NVIDIA', 'GeForce RTX 3060 Ti', 8192, 1.67, 399.99),
('AMD', 'Radeon RX 6600 XT', 8192, 2.59, 379.99),
('NVIDIA', 'GeForce GTX 1660 Super', 6144, 1.78, 229.99),
('AMD', 'Radeon RX 5600 XT', 6144, 1.61, 279.99),
('NVIDIA', 'GeForce RTX 2080 Ti', 11264, 1.54, 999.99),
('AMD', 'Radeon VII', 16384, 1.8, 699.99),
('NVIDIA', 'GeForce GTX 1650', 4096, 1.66, 149.99),
('AMD', 'Radeon RX 550', 4096, 1.1, 99.99),
('NVIDIA', 'GeForce GTX 1050 Ti', 4096, 1.34, 139.99),
('AMD', 'Radeon RX 570', 8192, 1.24, 169.99),
('NVIDIA', 'GeForce RTX 3090', 24576, 1.7, 1499.99);

alter table RAM
alter column ram_frequency decimal(7, 2);

insert into RAM (ram_brand, ram_model, ram_memorySize, ram_type, ram_frequency, ram_price)
values
('Corsair', 'Vengeance LPX', 16384, 'DDR4', 3200, 89.99),
('G.Skill', 'Trident Z RGB', 16384, 'DDR4', 3600, 119.99),
('Kingston', 'HyperX Fury', 8192, 'DDR4', 2666, 49.99),
('Crucial', 'Ballistix', 8192, 'DDR4', 3000, 54.99),
('TeamGroup', 'T-Force Delta RGB', 16384, 'DDR4', 3200, 79.99),
('Patriot', 'Viper Steel', 16384, 'DDR4', 3600, 99.99),
('Samsung', 'M391A2K43BB1-CTD', 8192, 'DDR4', 2400, 39.99),
('ADATA', 'XPG Spectrix D60G', 16384, 'DDR4', 3200, 74.99),
('Gigabyte', 'AORUS RGB', 16384, 'DDR4', 3600, 109.99),
('GeIL', 'Evo X II', 16384, 'DDR4', 3000, 79.99),
('PNY', 'XLR8', 16384, 'DDR4', 3200, 94.99),
('Silicon Power', 'XPower Turbine', 8192, 'DDR4', 3200, 42.99),
('Mushkin', 'Redline', 16384, 'DDR4', 3600, 129.99),
('Apacer', 'Panther Rage', 8192, 'DDR4', 3000, 49.99),
('Toshiba', 'RC100', 4096, 'DDR4', 2666, 29.99);

insert into Storage (storage_brand, storage_model, storage_type, storage_capacity, storage_price)
values
('Samsung', '970 EVO Plus', 'SSD', 1000, 129.99),
('WD', 'Black SN750', 'SSD', 1000, 119.99),
('Seagate', 'BarraCuda', 'HDD', 2000, 54.99),
('Toshiba', 'Canvio Basics', 'HDD', 4000, 99.99),
('Crucial', 'MX500', 'SSD', 500, 59.99),
('Kingston', 'A2000', 'SSD', 1000, 99.99),
('SanDisk', 'Ultra 3D', 'SSD', 2000, 189.99),
('ADATA', 'SU800', 'SSD', 1000, 94.99),
('Gigabyte', 'UD PRO', 'SSD', 512, 54.99),
('WD', 'Blue', 'HDD', 1000, 44.99),
('Seagate', 'IronWolf', 'HDD', 4000, 129.99),
('Toshiba', 'X300', 'HDD', 6000, 169.99),
('Samsung', '860 QVO', 'SSD', 1000, 114.99),
('Crucial', 'P2', 'SSD', 500, 49.99),
('WD', 'Elements', 'HDD', 8000, 199.99);

insert into PowerSup (powerSup_brand, powerSup_model, powerSup_powerWatt, powerSup_efficincy, powerSup_price)
values
('Corsair', 'RM850x', 850, '80 Plus Gold', 129.99),
('EVGA', 'SuperNOVA 750 G5', 750, '80 Plus Gold', 139.99),
('Seasonic', 'Focus GX-650', 650, '80 Plus Gold', 119.99),
('Cooler Master', 'MWE 550', 550, '80 Plus Bronze', 49.99),
('Thermaltake', 'Smart 600W', 600, '80 Plus', 44.99),
('Be Quiet!', 'Straight Power 11', 750, '80 Plus Gold', 159.99),
('SilverStone', 'Strider Essential', 500, '80 Plus', 39.99),
('NZXT', 'C850', 850, '80 Plus Gold', 129.99),
('Antec', 'Earthwatts Gold Pro', 650, '80 Plus Gold', 89.99),
('FSP', 'Hydro G Pro', 750, '80 Plus Gold', 109.99),
('Gigabyte', 'P750GM', 750, '80 Plus Gold', 99.99),
('Thermaltake', 'Toughpower GF1', 850, '80 Plus Gold', 149.99),
('Corsair', 'CX550M', 550, '80 Plus Bronze', 74.99),
('Cooler Master', 'V850', 850, '80 Plus Gold', 139.99),
('EVGA', '500 W1', 500, '80 Plus', 39.99);

insert into Mboard (mboard_brand, mboard_model, mboard_socket, mboard_chipset, mboard_formFactor, mboard_price)
values
('ASUS', 'ROG STRIX Z590-E', 'LGA1200', 'Z590', 'ATX', 299.99),
('MSI', 'MPG B550 GAMING EDGE', 'AM4', 'B550', 'ATX', 159.99),
('Gigabyte', 'AORUS X570 Master', 'AM4', 'X570', 'ATX', 349.99),
('ASRock', 'B460M Pro4', 'LGA1200', 'B460', 'Micro-ATX', 79.99),
('Biostar', 'TB360-BTC PRO', 'LGA1151', 'B360', 'ATX', 99.99),
('EVGA', 'Z490 DARK', 'LGA1200', 'Z490', 'ATX', 449.99),
('Supermicro', 'X11SAE', 'LGA1151', 'C236', 'ATX', 259.99),
('ASUS', 'TUF Gaming X570-Plus', 'AM4', 'X570', 'ATX', 189.99),
('MSI', 'MAG B460 TOMAHAWK', 'LGA1200', 'B460', 'ATX', 114.99),
('Gigabyte', 'Z590 AORUS ELITE', 'LGA1200', 'Z590', 'ATX', 199.99),
('ASRock', 'X570 Phantom Gaming', 'AM4', 'X570', 'ATX', 189.99),
('Biostar', 'A320MH', 'AM4', 'A320', 'Micro-ATX', 49.99),
('ASUS', 'PRIME Z390-A', 'LGA1151', 'Z390', 'ATX', 169.99),
('MSI', 'Z690 PRO DDR5', 'LGA1700', 'Z690', 'ATX', 329.99),
('Gigabyte', 'B560M DS3H', 'LGA1200', 'B560', 'Micro-ATX', 109.99);

insert into cCase (case_brand, case_model, case_formFactor, case_prise)
values
('NZXT', 'H510', 'ATX', 69.99),
('Corsair', '4000D Airflow', 'ATX', 94.99),
('Cooler Master', 'MasterBox Q300L', 'Micro-ATX', 39.99),
('Fractal Design', 'Meshify C', 'ATX', 109.99),
('Thermaltake', 'V200', 'ATX', 54.99),
('Phanteks', 'Eclipse P400A', 'ATX', 79.99),
('Be Quiet!', 'Pure Base 500DX', 'ATX', 99.99),
('Lian Li', 'PC-O11 Dynamic', 'ATX', 129.99),
('SilverStone', 'RL06', 'ATX', 74.99),
('Antec', 'NX410', 'ATX', 59.99),
('Gigabyte', 'AC300W', 'ATX', 84.99),
('Rosewill', 'Cullinan MX', 'ATX', 119.99),
('Deepcool', 'MACUBE 310', 'ATX', 64.99),
('Cooler Master', 'MasterCase H500', 'ATX', 149.99),
('Fractal Design', 'Define R6', 'ATX', 169.99);


alter table CPU
add default 'defaultBrand' for cpu_brand
alter table CPU
add default 'defaultModl' for cpu_model
alter table CPU
add default 1 for cpu_frequency
alter table CPU
add default 1 for cpu_cores
alter table CPU
add default 1 for cpu_threads
alter table CPU
add default 1 for cpu_price

insert into CPU(cpu_brand, cpu_model)
values
('test', 'test');
select * from CPU

alter table GPU
add default 'defaultBrand' for gpu_brand
alter table GPU
add default 'model' for gpu_model
alter table GPU
add default 1 for gpu_memorySize
alter table GPU
add default 1 for gpu_frequency
alter table GPU
add default 1 for gpu_price

alter table RAM
add default 'defaultBrand' FOR ram_brand;
alter table RAM
add default 'defaultModel' FOR ram_model;
alter table RAM
add default 1 FOR ram_memorySize;
alter table RAM
add default 'DDR4' FOR ram_type;
alter table RAM
add default 1 FOR ram_frequency;
alter table RAM
add default 1 FOR ram_price;

alter table Storage
add default 'defaultBrand' FOR storage_brand;
alter table Storage
add default 'defaultModel' FOR storage_model;
alter table Storage
add default 'SSD' FOR storage_type;
alter table Storage
add default 1 FOR storage_capacity;
alter table Storage
add default 1 FOR storage_price;

alter table PowerSup
add default 'defaultBrand' FOR powerSup_brand;
alter table PowerSup
add default 'defaultModel' FOR powerSup_model;
alter table PowerSup
add default 1 FOR powerSup_powerWatt;
alter table PowerSup
add default '80 Plus' FOR powerSup_efficincy;
alter table PowerSup
add default 1 FOR powerSup_price;

alter table Mboard
add default 'defaultBrand' FOR mboard_brand;
alter table Mboard
add default 'defaultModel' FOR mboard_model;
alter table Mboard
add default 'defaultSocket' FOR mboard_socket;
alter table Mboard
add default 'defaultChipset' FOR mboard_chipset;
alter table Mboard
add default 'ATX' FOR mboard_formFactor;
alter table Mboard
add default 1 FOR mboard_price;

alter table cCase
add default 'defaultBrand' FOR case_brand;
alter table cCase
add default 'defaultModel' FOR case_model;
alter table cCase
add default 'ATX' FOR case_formFactor;
alter table cCase
add default 1 FOR case_prise;

select * from cCase