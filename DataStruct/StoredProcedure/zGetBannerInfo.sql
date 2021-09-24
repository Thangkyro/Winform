Create proc zGetBannerInfo
 @BranchID int
AS
BEGIN
	SELECT
		branchID
		, BannerText
		, NumberOrder
		, Decriptions
		, ROW_NUMBER() OVER (ORDER BY BannerText) as STT
	FROM zBanner
	WHERE branchID = @BranchID
		AND is_inactive = 0
END
