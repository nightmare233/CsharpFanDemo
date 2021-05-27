DROP TABLE IF EXISTS `appinfo`;

CREATE TABLE `appinfo` (
`id` int(11) NOT NULL AUTO_INCREMENT,
`name` varchar(100) NOT NULL DEFAULT '',
`company` varchar(100) NOT NULL,
`city_id` int(11) NOT NULL,
`province_id` int(11) NOT NULL,
`description` varchar(1000) NOT NULL,
`installcount` int(11) NOT NULL,
`category_id` int(11) NOT NULL,
`subCategory_id` int(11) NOT NULL,
PRIMARY KEY (`id`)

) ENGINE=InnoDB AUTO_INCREMENT=392 DEFAULT CHARSET=gbk; 