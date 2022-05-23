CREATE DATABASE KT0720_61134177
GO

USE KT0720_61134177
GO


CREATE TABLE LOP
(
	MaLop VARCHAR(10) NOT NULL,
	TenLop NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE SINHVIEN
(
	MaSV VARCHAR(10) NOT NULL,
	HoSV NVARCHAR(50) NOT NULL,
	TenSV NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	GioiTinh BIT,
	AnhSV NVARCHAR(50),
	DiaChi NVARCHAR(100) NOT NULL,
	MaLop VARCHAR(10) NOT NULL
)
GO

---- Primary Key
ALTER TABLE dbo.LOP ADD CONSTRAINT PK_Lop PRIMARY KEY(MaLop)
ALTER TABLE dbo.SINHVIEN ADD CONSTRAINT PK_SinhVien PRIMARY KEY(MaSV)

---Foreign key

ALTER TABLE dbo.SINHVIEN ADD CONSTRAINT FK_SinhVien_Khoa FOREIGN KEY(MaLop) REFERENCES dbo.LOP(MaLop)


---Nhap du lieu

INSERT INTO dbo.LOP
(
    MaLop,
    TenLop
)
VALUES
(   '61CNTT2',
    N'61 Công nghệ thông tin 2'
    ),
(   '61NNA1',
    N'61 Ngôn Ngữ Anh 1'
    ),
(   '62TCNH3',
    N'62 Tài Chính Ngân Hàng 3'
    )
GO

INSERT INTO dbo.SINHVIEN
(
    MaSV,
    HoSV,
    TenSV,
    NgaySinh,
    GioiTinh,
    AnhSV,
    DiaChi,
    MaLop
)
VALUES
(   'SV001',
    N'Đặng Anh',
    N'Phú',
    CAST(N'2001-10-10' AS Date),
    1,
    N'sinhvien1.png',
    N'Quy Nhơn, Bình Định',
    '61CNTT2'
    ),
(   'SV002',
    N'Bùi Văn',
    N'Tình',
    CAST(N'2000-07-12' AS Date),
    1,
    N'sinhvien2.png',
    N'Phù Cát, Bình Định',
    '61NNA1'
    ),
(   'SV003',
    N'Nguyễn Thị',
    N'Hồng',
    CAST(N'2002-09-21' AS Date),
    0,
    N'sinhvien3.png',
    N'Nha Trang, Khánh Hòa',
    '62TCNH3'
    ),
(   'SV004',
    N'Trần Ánh',
    N'Phượng',
    CAST(N'2000-12-15' AS Date),
    1,
    N'sinhvien4.png',
    N'Ninh Hòa, Nha Trang',
    '61NNA1'
    )
GO

SELECT * FROM dbo.LOP
GO

SELECT * FROM dbo.SINHVIEN