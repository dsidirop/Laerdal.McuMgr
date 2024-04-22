﻿using Laerdal.McuMgr.Common.Enums;
using Laerdal.McuMgr.FileUploader.Contracts;
using Laerdal.McuMgr.FileUploader.Contracts.Enums;
using Laerdal.McuMgr.FileUploader.Contracts.Native;
using GenericNativeFileUploaderCallbacksProxy_ = Laerdal.McuMgr.FileUploader.FileUploader.GenericNativeFileUploaderCallbacksProxy;

namespace Laerdal.McuMgr.Tests.FileUploader
{
    public partial class FileUploaderTestbed
    {
        private class MockedNativeFileUploaderProxySpy : INativeFileUploaderProxy //template class for all spies
        {
            private readonly INativeFileUploaderCallbacksProxy _uploaderCallbacksProxy;

            public bool CancelCalled { get; private set; }
            public bool DisconnectCalled { get; private set; }
            public bool BeginUploadCalled { get; private set; }

            public string LastFatalErrorMessage => "";

            public IFileUploaderEventEmittable FileUploader //keep this to conform to the interface
            {
                get => _uploaderCallbacksProxy!.FileUploader;
                set => _uploaderCallbacksProxy!.FileUploader = value;
            }

            protected MockedNativeFileUploaderProxySpy(INativeFileUploaderCallbacksProxy uploaderCallbacksProxy)
            {
                _uploaderCallbacksProxy = uploaderCallbacksProxy;
            }

            public virtual EFileUploaderVerdict BeginUpload(string remoteFilePath, byte[] data)
            {
                BeginUploadCalled = true;

                return EFileUploaderVerdict.Success;
            }

            public virtual void Cancel()
            {
                CancelCalled = true;
            }

            public virtual void Disconnect()
            {
                DisconnectCalled = true;
            }

            public void CancelledAdvertisement() 
                => _uploaderCallbacksProxy.CancelledAdvertisement(); //raises the actual event
            
            public void LogMessageAdvertisement(string message, string category, ELogLevel level, string resource)
                => _uploaderCallbacksProxy.LogMessageAdvertisement(message, category, level, resource); //raises the actual event

            public void StateChangedAdvertisement(string resource, EFileUploaderState oldState, EFileUploaderState newState)
                => _uploaderCallbacksProxy.StateChangedAdvertisement(resource: resource, newState: newState, oldState: oldState); //raises the actual event

            public void BusyStateChangedAdvertisement(bool busyNotIdle)
                => _uploaderCallbacksProxy.BusyStateChangedAdvertisement(busyNotIdle); //raises the actual event
            
            public void FileUploadedAdvertisement(string resource)
                => _uploaderCallbacksProxy.FileUploadedAdvertisement(resource); //raises the actual event

            public void FatalErrorOccurredAdvertisement(
                string resource,
                string errorMessage,
                EMcuMgrErrorCode errorCode,
                EFileUploaderGroupReturnCode fileUploaderGroupReturnCode
            ) => _uploaderCallbacksProxy.FatalErrorOccurredAdvertisement(resource, errorMessage, errorCode, fileUploaderGroupReturnCode); //raises the actual event
            
            public void FileUploadProgressPercentageAndDataThroughputChangedAdvertisement(int progressPercentage, float averageThroughput)
                => _uploaderCallbacksProxy.FileUploadProgressPercentageAndDataThroughputChangedAdvertisement(progressPercentage, averageThroughput); //raises the actual event
            
            public bool TrySetContext(object context) => throw new NotImplementedException();
            public bool TrySetBluetoothDevice(object bluetoothDevice) => throw new NotImplementedException();
            public bool TryInvalidateCachedTransport() => throw new NotImplementedException();
            
            public void Dispose()
            {
            }

            public void CleanupResourcesOfLastUpload()
            {
            }
        }
    }
}