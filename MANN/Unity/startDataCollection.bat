for /l %%x in (1, 1, 2000) do (
	echo %%x
	start .\UnitySkeletonGeneratorEXE\UnitySkeletonGeneratorEXE.exe
	timeout /t 20 /nobreak>nul
	taskkill /f /im UnitySkeletonGeneratorEXE.exe
)