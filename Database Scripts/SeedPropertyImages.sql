USE PropertyHubApp;
GO

DECLARE @ApiBaseUrl NVARCHAR(200) = N'https://localhost:7210/media/';

WITH ImageFiles AS (
    SELECT *
    FROM (VALUES
        (1, N'1.jpg'),
        (2, N'2.jpg'),
        (3, N'3.jpg'),
        (4, N'4.jpg'),
        (5, N'5.jpg'),
        (6, N'6.jpg'),
        (7, N'7.jpg'),
        (8, N'8.jpg'),
        (9, N'9.jpg'),
        (10, N'10.jpg'),
        (11, N'11.jpg'),
        (12, N'12.jpg'),
        (13, N'13.jpg'),
        (14, N'14.jpg'),
        (15, N'15.jpg')
    ) AS MediaFiles(ImageOrder, FileName)
), RankedProperties AS (
    SELECT
        Id,
        ROW_NUMBER() OVER (ORDER BY Id) AS PropertyOrder
    FROM Properties
), ImageAssignments AS (
    SELECT
        property.Id AS PropertyId,
        image.FileName,
        image.ImageOrder
    FROM RankedProperties property
    INNER JOIN ImageFiles image
        ON image.ImageOrder = property.PropertyOrder
)
INSERT INTO PropertyImages (PropertyId, ImageUrl, IsPrimary, SortOrder)
SELECT
    assignment.PropertyId,
    CONCAT(@ApiBaseUrl, assignment.FileName) AS ImageUrl,
    1 AS IsPrimary,
    1 AS SortOrder
FROM ImageAssignments assignment
WHERE NOT EXISTS (
    SELECT 1
    FROM PropertyImages existingImage
    WHERE existingImage.PropertyId = assignment.PropertyId
      AND existingImage.ImageUrl = CONCAT(@ApiBaseUrl, assignment.FileName)
);
GO

SELECT
    property.Id,
    property.Title,
    image.ImageUrl,
    image.IsPrimary,
    image.SortOrder
FROM Properties property
LEFT JOIN PropertyImages image
    ON image.PropertyId = property.Id
ORDER BY property.Id, image.SortOrder, image.Id;
GO