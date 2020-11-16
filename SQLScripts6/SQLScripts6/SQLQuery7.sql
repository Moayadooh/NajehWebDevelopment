Exec dbo.sp_crudCategory @action='select' 

Exec dbo.sp_crudCategory @action='insert', @catname='testcat22', @desc='desc22'

Exec dbo.sp_crudCategory @action='update', @catname='testcat33', @desc='desc33', @catid=11

Exec dbo.sp_crudCategory @action='delete', @catid=11

Exec dbo.sp_crudCategory @action='byone', @catid=2
