using Consist.Doxi.Domain.Models;
using Consist.Doxi.Domain.Models.ExternalAPI;
using Flurl.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Doxi.APIClient;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using System.Net.Http;

namespace Doxi.APIClient
{
    public partial class DoxiClient
    {
        private const string DOCUMENT_BASE = "Document";

        public async Task<GetDocumentInfoResponse> DocumentInfo(byte[] document)
        {
            using (var stream = new MemoryStream(document))
            {
                var response = await GetServiceBaseUrl()
                    .AppendPathSegment(DOCUMENT_BASE)
                      .AppendPathSegment("DocumentInfo")
                    .PostMultipartAsync(mp => mp
                        .AddFile("document", stream, "document"))
                    .ReceiveJson<GetDocumentInfoResponse>();

                return response;
            }
        }

        public async Task<GetDocumentInfoResponse> DocumentInfoBase64(GetDocumentInfoRquest getDocumentInfoRquest)
        {
            return await GetServiceBaseUrl()
                      .AppendPathSegment(DOCUMENT_BASE)
                      .AppendPathSegment("DocumentInfoBase64")
                      .PostJsonAsync(getDocumentInfoRquest)
                      .ReceiveJson<GetDocumentInfoResponse>();
        }

        public async Task<SearchInDocumentResponse> SearchInDocumentBase64(SearchInDocumentBase64Request request)
        {
            return await GetServiceBaseUrl()
                       .AppendPathSegment(DOCUMENT_BASE)
                       .AppendPathSegment("SearchInDocumentBase64")
                       .PostJsonAsync(request)
                       .ReceiveJson<SearchInDocumentResponse>();
        }

        public async Task<SearchInDocumentResponse> SearchInDocument(byte[] file, SearchInDocumentRequest searchInDocumentRequest)
        {
            using (var stream = new MemoryStream(file))
            {
                return await GetServiceBaseUrl()
                    .AppendPathSegment(DOCUMENT_BASE)
                    .AppendPathSegment("SearchInDocument")
                    .PostMultipartAsync(mp => mp
                    .AddJson("SearchInDocumentRequest", searchInDocumentRequest)
                    .AddFile("file", stream, "file"))
                    .ReceiveJson<SearchInDocumentResponse>();
            }
        }

        public async Task<byte[]> MergeDocuments(IEnumerable<byte[]> documents)
        {
            var files = documents.Select(doc => new ByteArrayContent(doc)).ToList();

            using (var formData = new MultipartFormDataContent())
            {
                foreach (var fileContent in files)
                {
                    formData.Add(fileContent, "documents", "document");
                }

                var response = await GetServiceBaseUrl()
                    .AppendPathSegment(DOCUMENT_BASE)
                    .AppendPathSegment("MergeDocuments")
                    .PostAsync(formData);

                return await response.ResponseMessage.Content.ReadAsByteArrayAsync();
            }
        }
    }
}
