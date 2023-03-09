﻿namespace MyStore.Application.Categories.Queries.ExportTodos;

public class ExportItemsVm
{
    public ExportItemsVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }

    public string FileName { get; init; }

    public string ContentType { get; init; }

    public byte[] Content { get; init; }
}
