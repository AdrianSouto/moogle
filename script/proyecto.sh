
while [ true ]
do
echo "Ingrese un comando: (Escriba 'ayuda' para ver la lista de comandos)"
read input
case $input in
    run)
        cd ../
	dotnet watch run --project MoogleServer
        ;;
    report)
	cd ../informe/
       	pdflatex main.tex
        ;;
    slides)
        cd ../presentacion/
       	pdflatex main.tex
        ;;

    show_report)
	if [ -f ../informe/main.pdf ]
	then
       	start ../informe/main.pdf
	else
	cd ../informe/
       	pdflatex main.tex
	start ../informe/main.pdf
	fi
	;;
    show_slides)
	if [ -f ../presentacion/main.pdf ]
	then
       	start ../presentacion/main.pdf
	else
	cd ../presentacion/
       	pdflatex main.tex
	start ../presentacion/main.pdf
	fi
	;;
    clean)
	rm -f -v ../presentacion/*.aux
	rm -f -v ../presentacion/*.log
	rm -f -v ../presentacion/*.nav
	rm -f -v ../presentacion/*.out
	rm -f -v ../presentacion/*.snm
	rm -f -v ../presentacion/*.toc
	rm -f -v ../informe/*.aux
	rm -f -v ../informe/*.log
	;;
	ayuda)
	echo -e "run: ejectutar el proyecto \n\nreport: compilar y generar el pdf del proyecto latex relativo al informe \n\nslides: compilar y generar el pdf del proyecto latex relativo a la presentación \n\nshow_report: ejecutar un programa que permita visualizar el informe, si el fichero en pdf no ha sido generado debe generarse. Esta opción puede recibir como parámetro el comando de la herramienta de visualización que se quiera utilizar, aunque debe tener una por defecto. \n\nshow_slides: ejecutar un programa que permita visualizar la presentación, si el fichero en pdf no ha sido generado debe generarse. Esta opción puede recibir puede recibir como parámetro el comando de la herramienta de visualización que se quiera utilizar, aunque debe tener una por defecto. \n\nclean: eliminar todos los ficheros auxiliares que no forman parte del contenido del repositorio y se generan en la compilación o ejecución del proyecto, o en la generación de los pdfs del reporte o la presentación" 
	;;	
    *)
        echo "Ese comando no existe, escriba 'ayuda' para ver la lista de comandos"
        ;;
esac   
done 
#cd ../
#dotnet watch run --project MoogleServer