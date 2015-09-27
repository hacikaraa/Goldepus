using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aybala.DTO.Log;

namespace Aybala.Tool.Logger
{
    public class ErrorLog
    {
        private static _Data.DBConn data = new _Data.DBConn();

        public static bool CreateLog(string exceptionMessage, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, exceptionMessage, string.Empty, string.Empty, string.Empty, string.Empty, register, ReceiverMails);
        }

        public static bool CreateLog(string exceptionCode, string exceptionMessage, string note, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, string.Empty, string.Empty, string.Empty, string.Empty, exceptionCode, exceptionMessage, note, string.Empty, string.Empty, string.Empty, register, ReceiverMails);
        }

        public static bool CreateLog(string module, string className, string function, string exceptionCode, string exceptionMessage, string note, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, string.Empty, module, className, function, exceptionCode, exceptionMessage, note, string.Empty, string.Empty, string.Empty, register, ReceiverMails);
        }

        public static bool CreateLog(string projectName, string module, string className, string function, string exceptionCode, string exceptionMessage, string note, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, projectName, module, className, function, exceptionCode, exceptionMessage, note, string.Empty, string.Empty, string.Empty, register, ReceiverMails);
        }

        public static bool CreateLog(string projectName, string module, string className, string function, string exceptionCode, string exceptionMessage, string note, string description, string userIp, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, projectName, module, className, function, exceptionCode, exceptionMessage, note, description, userIp, string.Empty, register, ReceiverMails);
        }

        public static bool CreateLog(string projectName, string module, string className, string function, string exceptionCode, string exceptionMessage, string note, string description, string userIp, string device, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(0, projectName, module, className, function, exceptionCode, exceptionMessage, note, description, userIp, device, register, ReceiverMails);
        }

        public static bool CreateLog(int projectId, string projectName, string module, string className, string function, string exceptionCode, string exceptionMessage, string note, string description, string userIp, string device, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return SetAndCreateLog(projectId, projectName, module, className, function, exceptionCode, exceptionMessage, note, description, userIp, device, register, ReceiverMails);
        }

        public static bool CreateLog(ErrorLogObject errorLog, RegisterType register = RegisterType.DataBaseAndMail, List<string> ReceiverMails = null)
        {
            return RegisterLog(errorLog, register, ReceiverMails);
        }


        private static bool SetAndCreateLog(int projectId, string projectName, string module, string className, string function, string exceptionCode, string exceptionMessage, string note, string description, string userIp, string device, RegisterType register, List<string> ReceiverMails)
        {
            ErrorLogObject errorLog = new ErrorLogObject();
            errorLog.ProjectID = projectId;
            errorLog.ProjectName = projectName;
            errorLog.Module = module;
            errorLog.ClassName = className;
            errorLog.Function = function;
            errorLog.ExceptionCode = exceptionCode;
            errorLog.ExceptionMessage = exceptionMessage;
            errorLog.Note = note;
            errorLog.Description = description;
            errorLog.Device = device;
            errorLog.UserIp = userIp;
            errorLog.Date = DateTime.Now;
            return RegisterLog(errorLog, register, ReceiverMails);
        }

        private static bool RegisterLog(ErrorLogObject errorLog, RegisterType register, List<string> ReceiverMails)
        {
            switch (register)
            {
                case RegisterType.Database:
                    return Database(errorLog);
                case RegisterType.Mail:
                    return Mail(errorLog, ReceiverMails);
                case RegisterType.LogFile:
                    return LogFile(errorLog);
                case RegisterType.DataBaseAndMail:
                    return Database(errorLog) & Mail(errorLog, ReceiverMails);
                case RegisterType.LogFileAndMail:
                    return LogFile(errorLog) & Mail(errorLog, ReceiverMails);
                case RegisterType.DatabaseAndLogFile:
                    return Database(errorLog) & LogFile(errorLog);
                case RegisterType.All:
                    return Database(errorLog) & LogFile(errorLog) & Mail(errorLog, ReceiverMails);
                default:
                    throw new Exception("Log Kayıt Tipi Seçilmedi");
            }
        }

        private static bool Database(ErrorLogObject errorLog)
        {
            bool result = false;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            try
            {
                cmd.CommandText = @"INSERT INTO ErrorLog([Project],[ProjectName],[Module],[Class],[Function],[ExceptionCode],[ExceptionMessage],[Note],[Description],[Device],[UserIP],[CreatedDate]) 
                                                VALUES(@ProjectID,@ProjectName,@Module,@Class,@Function,@ExceptionCode,@ExceptionMessage,@Note,@Description,@Device,@UserIP,@CreatedDate)";
                if (String.IsNullOrEmpty(errorLog.ProjectName))
                    cmd.CommandText = cmd.CommandText.Replace("@ProjectName", "NULL");
                else
                    cmd.Parameters.Add("@ProjectName", System.Data.SqlDbType.VarChar).Value = errorLog.ProjectName;

                if (errorLog.ProjectID == 0)
                    cmd.CommandText = cmd.CommandText.Replace("@ProjectID", "NULL");
                else
                    cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = errorLog.ProjectID;

                if (String.IsNullOrEmpty(errorLog.Module))
                    cmd.CommandText = cmd.CommandText.Replace("@Module", "NULL");
                else
                    cmd.Parameters.Add("@Module", System.Data.SqlDbType.VarChar).Value = errorLog.Module;

                if (String.IsNullOrEmpty(errorLog.ClassName))
                    cmd.CommandText = cmd.CommandText.Replace("@Class", "NULL");
                else
                    cmd.Parameters.Add("@Class", System.Data.SqlDbType.VarChar).Value = errorLog.ClassName;

                if (String.IsNullOrEmpty(errorLog.Function))
                    cmd.CommandText = cmd.CommandText.Replace("@Function", "NULL");
                else
                    cmd.Parameters.Add("@Function", System.Data.SqlDbType.VarChar).Value = errorLog.Function;

                if (String.IsNullOrEmpty(errorLog.ExceptionCode))
                    cmd.CommandText = cmd.CommandText.Replace("@ExceptionCode", "NULL");
                else
                    cmd.Parameters.Add("@ExceptionCode", System.Data.SqlDbType.VarChar).Value = errorLog.ExceptionCode;

                if (String.IsNullOrEmpty(errorLog.ExceptionMessage))
                    cmd.CommandText = cmd.CommandText.Replace("@ExceptionMessage", "NULL");
                else
                    cmd.Parameters.Add("@ExceptionMessage", System.Data.SqlDbType.VarChar).Value = errorLog.ExceptionMessage;

                if (String.IsNullOrEmpty(errorLog.Note))
                    cmd.CommandText = cmd.CommandText.Replace("@Note", "NULL");
                else
                    cmd.Parameters.Add("@Note", System.Data.SqlDbType.VarChar).Value = errorLog.Note;

                if (String.IsNullOrEmpty(errorLog.Description))
                    cmd.CommandText = cmd.CommandText.Replace("@Description", "NULL");
                else
                    cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar).Value = errorLog.Description;

                if (String.IsNullOrEmpty(errorLog.Device))
                    cmd.CommandText = cmd.CommandText.Replace("@Device", "NULL");
                else
                    cmd.Parameters.Add("@Device", System.Data.SqlDbType.VarChar).Value = errorLog.Module;

                if (String.IsNullOrEmpty(errorLog.UserIp))
                    cmd.CommandText = cmd.CommandText.Replace("@UserIP", "NULL");
                else
                    cmd.Parameters.Add("@UserIP", System.Data.SqlDbType.VarChar).Value = errorLog.Module;

                if (errorLog.Date == DateTime.MinValue)
                    errorLog.Date = DateTime.Now;
                cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime).Value = errorLog.Date;

                result = data.Insert(cmd, _Data.DataBase.ErrorLog);
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Log Kaydı Atılamadı. Hata : " + ex.Message);
            }
            return result;
        }

        private static bool Mail(ErrorLogObject errorLog, List<string> ReceiverMails)
        {
            bool result = false;
            try
            {
                Aybala.DTO.Net.ReceiverObject receiver = new DTO.Net.ReceiverObject();
                receiver.Subject = "Hata Mesajı";

                #region MailFormat

                string mailBody = @"
                    Merhaba <br/>
                    Dahil olduğunuz [[projectName]] projesi içerisinde [[moduleName]] modülünde bir hata oluştu. Hata detayları : <br/>
                    <table>
                        <tr>
                           <td colspan='2'><hr /></td>
                        </tr>
                        <tr>
                            <td><b>Proje Adı</b></td>
                            <td>[[dProjectName]]</td>
                        </tr>
                        <tr>
                            <td><b>Modül Adı</b></td>
                            <td>[[dModuleName]]</td>
                        </tr>
                        <tr>
                            <td><b>Sınıf Adı</b></td>
                            <td>[[dFunction]]</td>
                        </tr>
                        <tr>
                            <td><b>Fonksiyon</b></td>
                            <td>[[dClassName]]</td>
                        </tr>
                        <tr>
                            <td><b>Hata Kodu</b></td>
                            <td>[[dExceptionCode]]</td>
                        </tr>
                        <tr>
                            <td><b>Hata Mesajı</b></td>
                            <td>[[dExceptionMessage]]</td>
                        </tr>
                        <tr>
                            <td><b>Not</b></td>
                            <td>[[dNote]]</td>
                        </tr>
                        <tr>
                            <td><b>Açıklama</b></td>
                            <td>[[dDescription]]</td>
                        </tr>
                        <tr>
                            <td><b>Cihaz Bilgisi</b></td>
                            <td>[[dDevice]]</td>
                        </tr>
                        <tr>
                            <td><b>Kullanıcı Ip</b></td>
                            <td>[[dUserIp]]</td>
                        </tr>
                        <tr>
                            <td><b>Hata Zamanı</b></td>
                            <td>[[dCreatedDate]]</td>
                        </tr>
                        <tr>
                            <td colspan='2'><hr /></td>
                        </tr>
                    </table><br/>
                    Hata ile en kısa sürede ilgilenmenizi rica ederiz. İyi Çalışmalar
                         ";
                #endregion

                #region MailFormat Edit
                mailBody = mailBody.Replace("[[projectName]]", errorLog.ProjectName);
                mailBody = mailBody.Replace("[[moduleName]]", errorLog.Module);
                mailBody = mailBody.Replace("[[dProjectName]]", errorLog.ProjectName);
                mailBody = mailBody.Replace("[[dModuleName]]", errorLog.Module);
                mailBody = mailBody.Replace("[[dClassName]]", errorLog.ClassName);
                mailBody = mailBody.Replace("[[dFunction]]", errorLog.Function);
                mailBody = mailBody.Replace("[[dExceptionCode]]", errorLog.ExceptionCode);
                mailBody = mailBody.Replace("[[dExceptionMessage]]", errorLog.ExceptionMessage);
                mailBody = mailBody.Replace("[[dNote]]", errorLog.Note);
                mailBody = mailBody.Replace("[[dDescription]]", errorLog.Description);
                mailBody = mailBody.Replace("[[dDevice]]", errorLog.Device);
                mailBody = mailBody.Replace("[[dUserIp]]", errorLog.UserIp);
                mailBody = mailBody.Replace("[[dCreatedDate]]", errorLog.Date.ToString());
                #endregion

                receiver.Body = mailBody;

                foreach (var item in ReceiverMails)
                    receiver.MailAddress += item + ",";
                receiver.MailAddress = receiver.MailAddress.Substring(0, receiver.MailAddress.Length - 1);
                result = Aybala.Tool.Net.Mail.Send(receiver);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

        private static bool LogFile(ErrorLogObject errorLog)
        {
            return true;
        }
    }

    public enum RegisterType
    {
        Database = 1,
        Mail = 2,
        LogFile = 3,
        DataBaseAndMail = 4,
        LogFileAndMail = 5,
        DatabaseAndLogFile = 6,
        All = 7
    }

}
