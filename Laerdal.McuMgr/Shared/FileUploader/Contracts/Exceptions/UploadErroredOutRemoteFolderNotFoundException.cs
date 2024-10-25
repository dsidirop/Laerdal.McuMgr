// ReSharper disable RedundantExtendsListEntry

using Laerdal.McuMgr.Common.Enums;
using Laerdal.McuMgr.FileUploader.Contracts.Enums;

namespace Laerdal.McuMgr.FileUploader.Contracts.Exceptions
{
    public sealed class UploadErroredOutRemoteFolderNotFoundException : UploadErroredOutException, IUploadException
    {
        public UploadErroredOutRemoteFolderNotFoundException(
            string nativeErrorMessage,
            string remoteFilePath,
            EMcuMgrErrorCode mcuMgrErrorCode,
            EFileOperationGroupErrorCode fileOperationGroupErrorCode
        ) : base(
            nativeErrorMessage: nativeErrorMessage,
            remoteFilePath: remoteFilePath,
            mcuMgrErrorCode: mcuMgrErrorCode,
            fileOperationGroupErrorCode: fileOperationGroupErrorCode
        )
        {
        }
    }
}
