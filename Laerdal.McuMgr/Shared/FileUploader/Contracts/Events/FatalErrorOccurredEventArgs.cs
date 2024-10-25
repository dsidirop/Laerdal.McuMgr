// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using Laerdal.McuMgr.Common.Enums;
using Laerdal.McuMgr.Common.Events;
using Laerdal.McuMgr.FileUploader.Contracts.Enums;

namespace Laerdal.McuMgr.FileUploader.Contracts.Events
{
    public readonly struct FatalErrorOccurredEventArgs : IMcuMgrEventArgs
    {
        public string ErrorMessage { get; }
        public string RemoteFilePath { get; }

        public EMcuMgrErrorCode ErrorCode { get; }
        public EFileOperationGroupErrorCode FileOperationGroupErrorCode { get; }

        public FatalErrorOccurredEventArgs(string remoteFilePath, string errorMessage, EMcuMgrErrorCode errorCode, EFileOperationGroupErrorCode fileOperationGroupErrorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            RemoteFilePath = remoteFilePath;
            FileOperationGroupErrorCode = fileOperationGroupErrorCode;
        }
    }
}
