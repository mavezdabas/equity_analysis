USE [master]
GO

/****** Object:  Database [EquityTradingApplication]    Script Date: 03/26/2014 15:26:48 ******/
CREATE DATABASE [EquityTradingApplication] ON  PRIMARY 
( NAME = N'EquityTradingApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EquityTradingApplication.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EquityTradingApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EquityTradingApplication_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EquityTradingApplication] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EquityTradingApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EquityTradingApplication] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET ARITHABORT OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EquityTradingApplication] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EquityTradingApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EquityTradingApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EquityTradingApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EquityTradingApplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EquityTradingApplication] SET  READ_WRITE 
GO

ALTER DATABASE [EquityTradingApplication] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EquityTradingApplication] SET  MULTI_USER 
GO

ALTER DATABASE [EquityTradingApplication] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EquityTradingApplication] SET DB_CHAINING OFF 
GO


