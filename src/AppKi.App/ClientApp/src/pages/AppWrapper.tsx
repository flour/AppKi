import React, {useEffect, useState} from "react";
import {useStore} from "effector-react";
import {getEnumRefsRequested} from "@pages/app.store";

interface AppWrapperProps {
  path?: string;
  className?: string;
  children:
    | React.ReactElement<any, string | React.JSXElementConstructor<any>>
    | string
    | number
    | undefined;
}

const AppWrapper: React.FC<AppWrapperProps> = (props: AppWrapperProps) => {
  const {children} = props;

  useEffect(() => {
    getEnumRefsRequested();
  }, []);

  return <>{children}</>
}

export default AppWrapper;