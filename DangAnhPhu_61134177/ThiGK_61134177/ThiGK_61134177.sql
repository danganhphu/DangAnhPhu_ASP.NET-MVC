CREATE DATABASE ThiGK_61134177
GO

USE ThiGK_61134177
GO

CREATE TABLE LoaiDocGia
(
	MaLoaiDocGia VARCHAR(10) NOT NULL,
	TenLoaiDocGia NVARCHAR(50) NOT NULL
)
GO


CREATE TABLE DocGia
(
	MaDG VARCHAR(10) NOT NULL,
	HoDG NVARCHAR(50) NOT NULL,
	TenDG NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	GioiTinh BIT,
	Email VARCHAR(50),
	AnhDG NVARCHAR(50),
	MaLoaiDocGia VARCHAR(10) NOT NULL
)
GO

---- Primary Key
ALTER TABLE dbo.LoaiDocGia ADD CONSTRAINT PK_LoaiDG PRIMARY KEY(MaLoaiDocGia)
GO

ALTER TABLE dbo.DocGia ADD CONSTRAINT PK_DocGia PRIMARY KEY(MaDG)
GO

---Foreign key

ALTER TABLE dbo.DocGia ADD CONSTRAINT FK_DocGia_LoaiDG FOREIGN KEY(MaLoaiDocGia) REFERENCES dbo.LoaiDocGia(MaLoaiDocGia)
GO

INSERT INTO dbo.LoaiDocGia
(
    MaLoaiDocGia,
    TenLoaiDocGia
)
VALUES
(   'LDG001',
    N'Sinh Viên'
    ),
(   'LDG002',
    N'Giảng Viên'
    ),
(   'LDG003', 
    N'Phụ Huynh'
    )
GO

INSERT INTO dbo.DocGia
(
    MaDG,
    HoDG,
    TenDG,
    NgaySinh,
    GioiTinh,
    Email,
    AnhDG,
    MaLoaiDocGia
)
VALUES
(   'DG01',
    N'Đặng Anh',
    N'Phú',
    CAST(N'2001-10-10' AS Date),
    1,
    'phuda@gmail.com',
    N'docgia1.png',
    'LDG001'
    ),
(   'DG02',
    N'Đặng Văn',
    N'Tình',
    CAST(N'1970-09-20' AS Date),
    1,
    'tinhda@gmail.com',
    N'docgia2.png',
    'LDG003'
    ),
(   'DG03', 
    N'Nguyễn Thị',
    N'Hồng',
    CAST(N'1989-07-12' AS Date),
    0,
    'hongnt@gmail.com',
    N'docgia3.png',
    'LDG002'
    )
GO

SELECT * FROM dbo.DocGia
GO
SELECT * FROM dbo.LoaiDocGia
GO
