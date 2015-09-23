pr report stord procedure

inventory report

F01-00757
AT0000001-0002



select  tbl_100_RR_Sub.ConvertedPrice
FROM         tbl_100_RR_Sub INNER JOIN
                      tbl_100_RR ON tbl_100_RR_Sub.RRNo = tbl_100_RR.RRNo
WHERE     (tbl_100_RR_Sub.ConvertedQTY <> 0) AND (CAST(tbl_100_RR_Sub.RRDate AS datetime) <= GETDATE()) AND (tbl_100_RR_Sub.SpecificCode = @input) 
                      AND (tbl_100_RR.isStatus <> N'CANCELLED')



Melodie P. Cañizares